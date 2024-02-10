using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1SpawnablesSelector : MonoBehaviour
{
    [SerializeField] private SpawnableObject[] _spawnables1;
    [SerializeField] private SpawnableObject[] _spawnables2;
    [SerializeField] private SpawnableObject[] _spawnables3;
    private SpawnableObject[] _selectedSpawnables;

    [Range(0f, 1f)][Tooltip("The sum of the spawn rates must be 1: ")]
    [SerializeField] private float _spawnRate1 = 0.7f;
    [Range(0f, 1f)][Tooltip("The sum of the spawn rates must be 1: ")]
    [SerializeField] private float _spawnRate2 = 0.3f;
    [Range(0f, 1f)][Tooltip("The sum of the spawn rates must be 1: ")]
    [SerializeField] private float _spawnRate3 = 0f;

    private void Start() {
        SelectRandomArray();
    }

    public SpawnableObject[] SelectRandomArray() {
        float randomValue = Random.value;

        if (randomValue < _spawnRate1) {
            return _spawnables1;
        }
        else if (randomValue < _spawnRate2 + _spawnRate1) {
            return _spawnables2;
        }
        else {
            return _spawnables3;
        }
    }
}
