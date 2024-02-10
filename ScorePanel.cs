using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField]
    private string[] _playerNames = new string[5];
    [SerializeField]
    private string[] _playerScores = new string[5];
    private string[] _names = new string[5];
    private int[] _scores = new int[5];

    [SerializeField]
    private TextMeshProUGUI[] _textNames = new TextMeshProUGUI[5];
    [SerializeField]
    private TextMeshProUGUI[] _textScores = new TextMeshProUGUI[5];

    private void Start() {
        FillScorePanel();
    }

    private void FillScorePanel() {

        string playerNameCurrent = PlayerPrefs.GetString("PlayerNameCurrent");
        int playerScoreCurrent = PlayerPrefs.GetInt("PlayerScoreCurrent");

        // Updating Saved Scores
        for (int index = 0; index < 5; index++) {
            _names[index] = PlayerPrefs.GetString(_playerNames[index]);
            _scores[index] = PlayerPrefs.GetInt(_playerScores[index]);
        }

        for (int index = 0; index < 5; index++) {
            if (playerScoreCurrent > _scores[index]) {

                for (int j = _scores.Length - 1; j > index; j--) {
                    _names[j] = _names[j - 1];
                    _scores[j] = _scores[j - 1];
                }

                _names[index] = playerNameCurrent;
                _scores[index] = playerScoreCurrent;
                break;
            }
        }

        Debug.Log("Names: " + string.Join(", ", _names));
        Debug.Log("Scores: " + string.Join(", ", _scores));

        for (int index = 0; index < 5; index++) {
            PlayerPrefs.SetString(_playerNames[index], _names[index]);
            PlayerPrefs.SetInt(_playerScores[index], _scores[index]);
        }

        // Updating Panel
        for (int index = 0; index < 5; index++) {
            _textNames[index].text = _names[index];
            _textScores[index].text = _scores[index].ToString();
        }

    }
}
