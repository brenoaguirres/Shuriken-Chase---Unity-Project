using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField _inputField;

    private const string PlayerNameKey = "PlayerNameCurrent";

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (!PlayerPrefs.HasKey(PlayerNameKey)) {
            PlayerPrefs.SetString(PlayerNameKey, "Empty");
            PlayerPrefs.SetInt("PlayerScoreCurrent", 0);
            PlayerPrefs.SetString("PlayerName1", "Empty");
            PlayerPrefs.SetInt("PlayerScore1", 0);
            PlayerPrefs.SetString("PlayerName2", "Empty");
            PlayerPrefs.SetInt("PlayerScore2", 0);
            PlayerPrefs.SetString("PlayerName3", "Empty");
            PlayerPrefs.SetInt("PlayerScore3", 0);
            PlayerPrefs.SetString("PlayerName4", "Empty");
            PlayerPrefs.SetInt("PlayerScore4", 0);
            PlayerPrefs.SetString("PlayerName5", "Empty");
            PlayerPrefs.SetInt("PlayerScore5", 0);
        }
    }

    public void SavePlayerName() {
        string playerName = _inputField.text;

        PlayerPrefs.SetString(PlayerNameKey, playerName);
    }
}
