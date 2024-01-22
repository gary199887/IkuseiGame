using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : CommonFunctions, MyButton
{
    public void onClicked() {
            SceneManager.LoadScene("GameScene");   
    }

    //マウスで選択している間の処理
    public void onPointing()
    {
        //ちょっと上げる？
        //大きさを変える？
        //色を変える？

        transform.position.Set(transform.position.x,transform.position.y-0.2f,transform.position.z);  

    }
        
}
