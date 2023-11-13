using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;   // �_�C�A���O�\���p�̃}�l�[�W���[Obj
    [SerializeField] GameObject buttons;            // �{�^���S�́A�{�^��on/off�؂�ւ��pGameObj
    [SerializeField] GameDirector gameDirector;     // �p�����[�^�[�ύX�pGameDirector Obj
    public Effect effect;                           // �s���ɋN�����ꂽ�ω�
    Action[] actions = {new Action("Throw"), new Action("Study"), new Action("Talk")};  // �s��Lv�v�Z�p(�������A�׋��A�b��������)

    public void onWateringButtonClicked() {     // �����{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        closeButtons();
        string[] msg;
       
        effect = new Effect(3, 30, 0, 0, 1, 1);
        GameDirector.changeParameter(effect);
        msg = new string[] { "����������", effect.getPlusMsg(), effect.getMinusMsg()};
       
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // ��������{�^���N���b�N���ꂽ���ɌĂяo�����\�b�h
        string[] msg;
        if (getSuccessOrNot(GameDirector.chara.getHp() + 20))   // �L������HP�ɉ����čs������/���s����@20�i��b�������j+ �L����HP (0 ~ 100)
        {
            // �s��lv�ɉ����ĕω�����l(power)���ϓ�  5�i��b�l�j + 30 x �s��lv(1 ~ 5) / 5
            effect = new Effect(3, -30, 5 + (int)Mathf.Ceil(30 * ((float)actions[0].getLv() / 5)), 0, 0, 0);
            // �s���񐔒ǉ��A���x���A�b�v�`�F�b�N
            string lvUpMsg = actions[0].doAction();
            // �G�t�F�N�g�̃p�����[�^�ɑΉ������L�����X�e�[�^�X�ύX����
            GameDirector.changeParameter(effect);

            // �\�����b�Z�[�W�i���x���A�b�v�������j
            if (lvUpMsg != null) msg = new string[] { "��������", effect.getPlusMsg(), effect.getMinusMsg(), lvUpMsg };
            else msg = new string[] { "��������", effect.getPlusMsg(), effect.getMinusMsg() };
        }
        else    // �s�����s����
        {
            // ���Ԍo�߁B�̗́A�D���x���Z
            effect = new Effect(3, -20, 0, 0, 0, -2);
            // �G�t�F�N�g�̃p�����[�^�ɑΉ������L�����X�e�[�^�X�ύX����
            GameDirector.changeParameter(effect);
            // �\�����b�Z�[�W
            msg = new string[] { "�s���Ɏ��s����", effect.getPlusMsg(), effect.getMinusMsg() };
        }
        // ���b�Z�[�W���_�C�A���O�ɕ\��
        dialogManager.showDialog(msg);
    }

    public void onStudyButtonClicked(){        // �׋�������{�^���N���b�N���ꂽ���ɌĂяo�����\�b�h
        effect = new Effect(3, -30, 0, 30, 0, 0);
        GameDirector.changeParameter(effect);
        string[] msg = {"�׋�������", effect.getPlusMsg(), effect.getMinusMsg() };
        dialogManager.showDialog(msg);
    }
    public void onItemButtonClicked() {        //�@�A�C�e���g�p�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        string[] msg = { "�A�C�e�����g�p����" };
        dialogManager.showDialog(msg);
    }

    public void onTalkingButtonClicked()    //�@��b�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    {
        effect = new Effect(3, -30, 0, 0, 30, 0);
        GameDirector.changeParameter(effect);
        string[] msg = { "�b��������", effect.getPlusMsg(), effect.getMinusMsg() };
        dialogManager.showDialog(msg);

    }

    public void onOutingButtonClicked()     //�@��b�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    {
        // �C�x���g���������ǉ��\��
        string[] msg = { "���o��������" };
        dialogManager.showDialog(msg);
    }

    // �s���I���{�^��������
    public void closeButtons() { 
        buttons.SetActive(false);
    }

    // �s���I���{�^����߂�
    public void showButtons() {
        buttons.SetActive(true);
    }

    // �s���I����̃_�C�A���O���鎞�ɌĂяo�����\�b�h
    public void afterActionDialogClosed() {
        gameDirector.revealStatusInUI();

        // ���ԉ��Z  �����o�߂�����ꍇ��true 
        if (!gameDirector.addTime(effect.time))     // �������o�߂��Ȃ������ꍇ�ior �G���f�B���O�ɐi�ޏꍇ�j
            effect = null;                          // effect��null�ɖ߂�

        // ���Ԃ�UI�ɔ��f
        gameDirector.revealTimeUI();
    }

    // ���I�i�p�[�Z���e�[�W�j���\�b�h
    bool getSuccessOrNot(int percentage) {
        if(Random.Range(1, 101) <= percentage)
            return true;
        return false;
    }
}
