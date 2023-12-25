using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour, MyButton
{
    public void onClicked(){

    #if UNITY_EDITOR                                        // environment check
        UnityEditor.EditorApplication.isPlaying = false;    // end game
    #else
                Application.Quit();                                 // end game
    #endif
    }
}
