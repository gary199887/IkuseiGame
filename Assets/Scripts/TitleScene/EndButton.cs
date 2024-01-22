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

    public void onPointing()
    {
        transform.position.Set(transform.position.x, transform.position.y - 0.2f, transform.position.z);
    }
}
