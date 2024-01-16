using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public void loadButtonClicked() {
        GameDirector.loadGame = true;
        SceneManager.LoadScene("GameScene");
    }
}
