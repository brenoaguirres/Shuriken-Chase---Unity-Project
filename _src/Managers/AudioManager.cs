using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton Pattern
    public static AudioManager instance;
    #endregion
    private bool _isMute = false;
    [SerializeField] AudioSource _audioSrc;
    [SerializeField] AudioClip _bgm;

    private void Awake() 
    {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        // if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        // }
    }
    private void Start() 
    {
        _audioSrc = GetComponent<AudioSource>();
        PlayBGM(_bgm);
    }

    public void PlayBGM(AudioClip bgmClip) {
        if (!_isMute) {
            _audioSrc.clip = bgmClip;
            _audioSrc.volume = 0.6f;
            _audioSrc.Play();
        }
    }

    public void PlaySound(AudioClip audio) {
        if (!_isMute) {
            _audioSrc.PlayOneShot(audio);
        }
    }

    public void StopBGM() {
        _audioSrc.Stop();
    }

}
