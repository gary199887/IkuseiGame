using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : CommonFunctions, MyButton
{
    public void onClicked() {
            SceneManager.LoadScene("GameScene");   
    }

    //�}�E�X�őI�����Ă���Ԃ̏���
    public void onPointing()
    {
        //������Əグ��H
        //�傫����ς���H
        //�F��ς���H

        transform.position.Set(transform.position.x,transform.position.y-0.2f,transform.position.z);  

    }
        
}
