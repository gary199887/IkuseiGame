using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;
    [SerializeField] GameObject buttons;
    public void onWateringButtonClicked() {     // ��Ƃ��Đ����{�^�����N���b�N���ꂽ���Ăяo���󃁃\�b�h
        closeButtons();
        string[] msg = { "����������" };
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // 
    
    }
    public void onItemButtonClicked() {        //�@�A�C�e���g�p�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    
    }

    public void onTalkingButtonClicked()
    {
        Debug.Log("�����������I������");
    }

    public void onOutingButtonClicked()
    {
        Debug.Log("�o�������I������");
    }

    void closeButtons() { 
        buttons.SetActive(false);
    }

    public void showButtons() {
        buttons.SetActive(true);
    }

}
