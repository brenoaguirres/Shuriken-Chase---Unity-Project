using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton Pattern
    public static GameManager instance;
    #endregion

    [SerializeField] private HealthController _playerHealth;
    private bool _canTriggerReset = true;
    [SerializeField] private float _timeToReset;

    private void Awake() 
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update() {
        ResetGame();
    }

    private void ResetGame() {
        if (!_playerHealth._isAlive) {
            if (_canTriggerReset) {
                StartCoroutine(WaitForReset(_timeToReset));
            }
        }
    }

    private IEnumerator WaitForReset(float seconds) {
        _canTriggerReset = false;
        yield return new WaitForSeconds(seconds);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        BroadcastMessage("StartGame");
    }
}
