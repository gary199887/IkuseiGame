using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton :CommonFunctions, MyButton
{
    public void loadButtonClicked() {
        GameDirector.loadGame = true;
        SceneManager.LoadScene("GameScene");
    }

    public void onClicked()
    {
        loadButtonClicked();
    }

}
