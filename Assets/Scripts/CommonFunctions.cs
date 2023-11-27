using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonFunctions : MonoBehaviour
{
    float timeCnt;
    
    public void tenmetsu(GameObject obj)     // switch active/inactive of gameobject constantly
    {
        if (timeCnt > 0.7f)
        {
            obj.SetActive(obj.activeSelf ? false : true);
            timeCnt = 0;
        }
        timeCnt += Time.deltaTime;
    }

    public void clearTimer() {
        timeCnt = 0;
    }

    public IEnumerator DelayMethod(float waitTime, System.Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    public static void endGameWithEsc()
    {
        //Esc clicked
        if (Input.GetButtonDown("Cancel"))
        {

            #if UNITY_EDITOR                                        // environment check
                UnityEditor.EditorApplication.isPlaying = false;    // end game
            #else
                Application.Quit();                                 // end game
            #endif
        }

    }

    public void jumpSceneAfterWait(string sceneName, float sec) {
        StartCoroutine(DelayMethod(sec, () =>
        {
            clearTimer();
            SceneManager.LoadScene(sceneName);
        }));
    }
    public static string[] stringAddToLast(string[] originalString, string addString)
    {
        List<string> result = new List<string>(originalString.ToList<string>());
        result.Add(addString);
        return result.ToArray();
    }
}
