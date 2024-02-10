using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXComponent : MonoBehaviour
{
    [SerializeField] protected AudioClip[] _sfxCollection;
    
    public void PlaySFX(AudioClip sfx) {
        AudioManager.instance.PlaySound(sfx);
    }
}
