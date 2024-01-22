using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton :CommonFunctions, MyButton
{
    void Start()
    {
        SaveData saveData = SaveIO.DataLoad();
        if(saveData == null) gameObject.SetActive(false);
    }
    public void loadButtonClicked() {
        GameDirector.loadGame = true;
        SceneManager.LoadScene("GameScene");
    }

    public void onClicked()
    {
        loadButtonClicked();
    }

}
