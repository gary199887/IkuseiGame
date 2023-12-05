using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButton : MonoBehaviour
{
    [SerializeField] GameDirector gameDirector;
    public void onDayPassClicked() {
        gameDirector.debugDayPass();
    }
}
