using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;
    [SerializeField] GameObject buttons;
    public void onWateringButtonClicked() {     // ��Ƃ��Đ����{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        closeButtons();
        string[] msg = { "����������" };
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // ��������{�^���N���b�N���ꂽ���ɌĂяo�����\�b�h
        closeButtons();
        string[] msg = {"��������"};
        dialogManager.showDialog(msg);
    }

    public void onStudyButtonClicked() {
        closeButtons();
        string[] msg = {"�׋�������"};
        dialogManager.showDialog(msg);
    }
    public void onItemButtonClicked() {        //�@�A�C�e���g�p�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        closeButtons();
        string[] msg = { "�A�C�e�����g�p����" };
        dialogManager.showDialog(msg);
    }

    public void onTalkingButtonClicked()    //�@��b�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    {
        closeButtons();
        string[] msg = { "�b��������", "�����^�����オ����" };
        dialogManager.showDialog(msg);

    }

    public void onOutingButtonClicked()     //�@��b�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    {
        closeButtons();
        string[] msg = { "���o��������" };
        dialogManager.showDialog(msg);
    }

    void closeButtons() { 
        buttons.SetActive(false);
    }

    public void showButtons() {
        buttons.SetActive(true);
    }

}
