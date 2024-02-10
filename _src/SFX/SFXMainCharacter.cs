using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMainCharacter : SFXComponent
{
    private void SFXLaneChange() {
        PlaySFX(_sfxCollection[0]);
    }

    private void SFXAttack() {
        PlaySFX(_sfxCollection[1]);
    }

    private void SFXJump() {
        PlaySFX(_sfxCollection[2]);
    }

    private void SFXDeath() {
        PlaySFX(_sfxCollection[3]);
    }
}
