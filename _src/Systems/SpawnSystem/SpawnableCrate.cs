using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableCrate : SpawnableObject
{
    public new void ResetObject() {
        GetComponent<CrateBehaviour>().DisableCrate();
        transform.position = _initialPos;
    }
}
