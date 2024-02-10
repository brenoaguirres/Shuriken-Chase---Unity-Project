using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSource : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 0;
    [SerializeField] private TextScore _text;
    
    public string GetScoreValue() {
        return _scoreValue.ToString();
    }

    public void SetScore() {
        _text.AddScore(_scoreValue);
    }
}
