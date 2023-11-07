using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;   // �_�C�A���O�\���p�̃}�l�[�W���[Obj
    [SerializeField] GameObject buttons;            // �{�^���S�́A�{�^��on/off�؂�ւ��pGameObj
    [SerializeField] GameDirector gameDirector;     // �p�����[�^�[�ύX�pGameDirector Obj
    public Effect effect;
    public void onWateringButtonClicked() {     // ��Ƃ��Đ����{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        closeButtons();
        effect = new Effect(2, 0, 0, 1, 1);
        string[] msg = { "����������", effect.toPlusString() };
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // ��������{�^���N���b�N���ꂽ���ɌĂяo�����\�b�h
        closeButtons();
        effect = new Effect(-1, 3, 0, -1, -1);
        string[] msg = {"��������", effect.toPlusString()};
        dialogManager.showDialog(msg);
    }

    public void onStudyButtonClicked() {
        closeButtons();
        effect = new Effect(-1, 0, 2, 0, 0);
        string[] msg = {"�׋�������", effect.toPlusString()};
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

    public void changeParameters() {
        gameDirector.changeParameter(effect);
        effect = null;
    }
}
