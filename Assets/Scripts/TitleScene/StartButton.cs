using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : CommonFunctions, MyButton
{
    public void onClicked() {
            SceneManager.LoadScene("GameScene");   
    }

        
}
