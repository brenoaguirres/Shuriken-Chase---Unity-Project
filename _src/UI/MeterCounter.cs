using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterCounter : MonoBehaviour
{
    private float _meterCount = 0f;
    private float _timeCount = 0f;
    private float _totalCount = 0f;
    [SerializeField] private float _intervalCount = 0.02f;
    [SerializeField] private float _centimetersByInterval = 40f;

    //Score
    [SerializeField] private TextScore textScore;
    [SerializeField] private int meterScoreValue = 50;
    [SerializeField] private int _lastMeters = 0;
    [SerializeField] private int _currentMeters = 0;

    void Start()
    {
      
    }

    void FixedUpdate()
    {
        _timeCount += Time.fixedDeltaTime;
        if (_timeCount >= _intervalCount) {
            _totalCount += _intervalCount;
            _timeCount = 0f;
        }

        if (_totalCount >= 1) {
            _meterCount = (_totalCount * _centimetersByInterval) / 100;
        }

        //Score
        _currentMeters = (int)_meterCount;
        if (_currentMeters > _lastMeters) {
            _lastMeters = _currentMeters;
            textScore.AddScore(meterScoreValue + (int)_meterCount);
        }
    }

    public string GetMetersString() {
        return (_meterCount.ToString("0") + " m");
    }
}
