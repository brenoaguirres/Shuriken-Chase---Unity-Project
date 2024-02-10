using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void StartGame() {
        int sceneIndex = (SceneManager.GetActiveScene().buildIndex) +1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ResetGame() {
        ResetCurrentScore();
        int sceneIndex = 2;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ResetCurrentScore() {
        PlayerPrefs.SetInt("PlayerScoreCurrent", 0);
    }
}
