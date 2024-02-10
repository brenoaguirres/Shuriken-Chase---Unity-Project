using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Tooltip("Insert here the spawn positions of the lanes.")]
    [SerializeField] private Transform[] _spawnPositions;
    private int _currentSpawn = -1;

    [Tooltip("Min possible time between spawns.")]
    [SerializeField] private float minTimer = 0.5f;
    [Tooltip("Max possible time between spawns.")]
    [SerializeField] private float maxTimer = 2f;
    private bool _canSpawn = false;
    private float _startingTimer = 0f;
    private float _intervalTimer;

    [Tooltip("Max possible spawns on the same lane.")]
    private int _maxPossibleSpawns = 3;
    private int _spawnOnLaneCount = 0;

    private bool _isThisSectionRandom = true;

    [SerializeField] private SpawnableObject[] _spawnables;
    private LV1SpawnablesSelector _spawnablesSelector;
    private int _spawnablesCursor = 0;
    // crate variables
    [SerializeField] private SpawnableCrate _spawnableCrate;
    private float _startingTimerCrate = 0f;
    [SerializeField] private float _minTimerCrate = 1f;
    [SerializeField] private float _maxTimerCrate = 2f;
    private float _intervalTimerCrate;
    private bool _canSpawnCrate = false;

    private void Start() {
        _spawnablesSelector = GetComponent<LV1SpawnablesSelector>();
        ResetTimer();
        ResetTimerCrate();
    }

    void Update()
    {
        if (_isThisSectionRandom) {
            CheckIfCanSpawn();
            CheckIfCanSpawnCrate();
        }
    }

    private void ResetTimer() {
        float ran = Random.Range(minTimer, maxTimer);
        _intervalTimer = Time.time + ran;
    }

    private void ResetTimerCrate() {
        float ran = Random.Range(_minTimerCrate, _maxTimerCrate);
        _intervalTimerCrate = Time.time + ran;
    }

    private void CheckIfCanSpawn(){
        _startingTimer = Time.time;
        if (_startingTimer >= _intervalTimer) {
            _canSpawn = true;
        }


        if (_canSpawn) {
            _spawnables = _spawnablesSelector.SelectRandomArray();
            Spawn();
        }
    }

    private void CheckIfCanSpawnCrate() {
        _startingTimerCrate = Time.time;
        if (_startingTimerCrate >= _intervalTimerCrate) {
            _canSpawnCrate = true;
        }

        if (_canSpawnCrate) {
            SpawnCrate();
        }
    }

    private void Spawn()
    {
        SetRandomSpawn();
        SetSpawnPos();
        ResetSpawner();
    }

    private void SpawnCrate() {
        SetRandomSpawn();
        SetCrateSpawnPos();
        ResetCrateSpawner();
    }

    private void SetRandomSpawn() {
        if (_currentSpawn == -1) {
            if (_maxPossibleSpawns >= _spawnOnLaneCount) {
                int _lastSpawn = _currentSpawn;   
                _currentSpawn = (int)Random.Range(0, _spawnPositions.Length);
                if (_lastSpawn == _currentSpawn){
                    _spawnOnLaneCount++;
                }
                else {
                    _spawnOnLaneCount = 0;
                }
            }
            else {
                int _lastSpawn = _currentSpawn;
                while (_lastSpawn == _currentSpawn) {
                    _currentSpawn = (int)Random.Range(0, _spawnPositions.Length);                
                }
                _spawnOnLaneCount = 0;
            }
        }
    }

    private void SetSpawnPos() {
        bool isNotInUse = false;

        if (_spawnablesCursor > _spawnables.Length - 1)
        {
            _spawnablesCursor = 0;
        }

        if (_spawnables[_spawnablesCursor].IsCurrrentlyInUse() == true) {
                isNotInUse = false;
                _spawnablesCursor++;
        }
        else {
            isNotInUse = true;
        }
        
        if (isNotInUse) {
            _spawnables[_spawnablesCursor].GetComponent<BasicMovement>().enabled = true;
            _spawnables[_spawnablesCursor].transform.position = _spawnPositions[_currentSpawn].transform.position;
        }
    }

    private void SetCrateSpawnPos() {
        bool isNotInUse = false;

        if (_spawnableCrate.IsCurrrentlyInUse() == true) {
            isNotInUse = false;
        }
        else {
            isNotInUse = true;
        }

        if (isNotInUse) {
            _spawnableCrate.GetComponent<CrateBehaviour>().EnableCrate();
            _spawnableCrate.transform.position = _spawnPositions[_currentSpawn].transform.position;
        }
    }

    private void ResetSpawner() {
        _canSpawn = false;
        ResetTimer();
        _currentSpawn = -1;
    }

    private void ResetCrateSpawner() {
        _canSpawnCrate = false;
        ResetTimerCrate();
        _currentSpawn = -1;
    }
}
