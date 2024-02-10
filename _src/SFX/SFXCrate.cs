using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCrate : SFXComponent
{
    private void SFXBreak() {
        PlaySFX(_sfxCollection[0]);
    }
}
