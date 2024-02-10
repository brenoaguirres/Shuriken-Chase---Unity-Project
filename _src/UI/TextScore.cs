using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    private int _playerScore = 0;
    private TMP_Text _textComponent;

    private void Start() {
        _textComponent = GetComponent<TMP_Text>();
        SetScoreText(_playerScore);
    }

    private void Update() {
        SetScoreText(_playerScore);
        PlayerPrefs.SetInt("PlayerScoreCurrent", _playerScore);
    }

    public void AddScore(int score) {
        _playerScore += score;
    }

    public void SetScoreText(int newScore) {
        _textComponent.text = newScore.ToString();
    }
}
