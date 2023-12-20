using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;   // �_�C�A���O�\���p�̃}�l�[�W���[Obj
    [SerializeField] GameObject buttons;            // �{�^���S�́A�{�^��on/off�؂�ւ��pGameObj
    [SerializeField] GameDirector gameDirector;     // �p�����[�^�[�ύX�pGameDirector Obj
    [SerializeField] HintManager hintManager;
    [SerializeField] OutingEventManager outingEventManager;     // �O�o�C�x���g�p�}�l�[�W���[obj
    [SerializeField] AudioSource SEAudio;   //SE�pAudioSource
    public Effect effect;                           // �s���ɋN�����ꂽ�ω�
    enum actionWithLv { ��������, �׋�������, �b�������� };      // �s�����x���̂���s����(���s����\��������)
    public static Action[] actions;  // �s��Lv�v�Z�p(�������A�׋��A�b��������)
    int doLvUp;         // �s�����x���A�b�v����ۂɎg�p�����iindex�j

    void Start()
    {
        effect = null;
        actions = new Action[]{ new Action("Throw"), new Action("Study"), new Action("Talk"), new Action("Out"), new Action("Medicine"), new Action("Water")};
        doLvUp = -1;
    }
    public void onWateringButtonClicked() {     // �����{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        closeButtons();
        string[] msg;
        SEAudio.Play();
        effect = new Effect(5, 40, 0, 0, 0, 3);
        gameDirector.changeParameter(effect);
        msg = new string[] { "����������", effect.getPlusMsg(), effect.getMinusMsg()};
        actions[5].times++;

        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // ��������{�^���N���b�N���ꂽ���ɌĂяo�����\�b�h
        doActionWithLv(actionWithLv.��������);
        SEAudio.Play();
    }

    public void onStudyButtonClicked(){        // �׋�������{�^���N���b�N���ꂽ���ɌĂяo�����\�b�h
        doActionWithLv(actionWithLv.�׋�������);
        SEAudio.Play();
    }
    public void onItemButtonClicked() {        //�@�A�C�e���g�p�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
        string successOrNot = "";
        if (getSuccessOrNot(50))
        {
            successOrNot = "���ʂ̓o�c�O���̂悤���I";
            effect = new Effect(7, -10, 30, 30, 30, -10);
        }
        else
        {
            successOrNot = "�܂����A���������򂪋t��p���N�������悤���I";
            effect = new Effect(7, -30, -30, -30, -30, -20);
        }
        gameDirector.changeParameter(effect);
        string[] msg = { "�ςȖ�𒍓�����", successOrNot, effect.getPlusMsg(), effect.getMinusMsg()};
        dialogManager.showDialog(msg);
        SEAudio.Play();
        actions[4].times++;
    }

    public void onTalkingButtonClicked()    //�@��b�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    {
        doActionWithLv(actionWithLv.�b��������);
        SEAudio.Play();
    }

    public void onOutingButtonClicked()     //�@�O�o�{�^�����N���b�N���ꂽ���Ăяo�����\�b�h
    {
        actions[3].times++;
        outingEventManager.DoOutingEvent(actions);
        SEAudio.Play();
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

        if (doLvUp > -1) {  // ���x���A�b�v�������ǂ���
            // �A�b�v�����s�����x����UI��ɔ��f
            hintManager.lvUpInUI(doLvUp, actions[doLvUp].getLv());
            // ���f�p�̕ϐ���-1�ɖ߂�
            doLvUp = -1;
        }

        // ��������UI�ɔ��f
        for(int i = 0; i < 3; ++i)
            hintManager.successChangeInUI(i, getSuccessPercentage(i));

        // ���ԉ��Z  �����o�߂�����ꍇ��true 
        if (!gameDirector.addTime(effect.time))     // �������o�߂��Ȃ������ꍇ�ior �G���f�B���O�ɐi�ޏꍇ�j
            effect = null;                          // effect��null�ɖ߂�

        // ���Ԃ�UI�ɔ��f
        gameDirector.revealTimeUI();

        if (GameDirector.chara.getHp() == 0 && (GameDirector.currentDay < 29 ||  (GameDirector.currentDay == 28 && GameDirector.currentHour < 19))) {
            effect = new Effect(4, 20);
            effect.friendly = -10;
            gameDirector.changeParameter(effect);
            string[] msg = new string[] {"HP���[���ɂȂ��čs���s�\�ɂȂ���", "�D���x����������", "4���ԋx�e����..."};
            dialogManager.showDialog(msg);
        }
    }

    // ���I�i�p�[�Z���e�[�W�j���\�b�h
    bool getSuccessOrNot(int percentage) {
        if(Random.Range(1, 101) <= percentage)
            return true;
        return false;
    }

    // �s�����Ƃ̐��������擾���郁�\�b�h
    int getSuccessPercentage(int actionId)
    {
        // �D���x��10�{HP�̎c�ʁ{5 - �s�����x��*2
        return Mathf.Clamp(5 + GameDirector.chara.getHp() - actions[actionId].getLv() * 2 + GameDirector.chara.getFriendly() / 10, 0, 100);
    }

    // ���s���邱�Ƃ�����s�����Ƃ鎞�ɌĂяo�����\�b�h
    void doActionWithLv(actionWithLv actionName) {
        string[] msg;           // �_�C�A���O�ɕ\������郁�b�Z�[�W
        string actionMsg = "";  // �s���ʂɕς��ŏ��̃��b�Z�[�W
        if (getSuccessOrNot(getSuccessPercentage((int) actionName)))   // �L������HP�ɉ����čs������/���s����@5�i��b�������j+ �L����HP (0 ~ 100) + �s�����x��(1~5) * 5
        {
            // �s��lv�ɉ����ĕω�����l���ϓ� 30 x �s��lv(1 ~ 5) / 5
            effect = new Effect();
            effect.time = 5;
            effect.hp = -30;
            int changeValue = (int)Mathf.Ceil(30 * ((float)actions[(int)actionName].getLv() / 5));
            switch (actionName) {
                case actionWithLv.��������:
                    effect.power = changeValue;
                    actionMsg = "��������";
                    break;
                case actionWithLv.�׋�������:
                    effect.intelligent = changeValue;
                    actionMsg = "�׋�������";
                    break;
                case actionWithLv.�b��������:
                    effect.mental = changeValue;
                    actionMsg = "�b��������";
                    break;
            }


            // �s���񐔒ǉ��A���x���A�b�v�`�F�b�N
            string lvUpMsg = actions[(int)actionName].doAction();
            // �G�t�F�N�g�̃p�����[�^�ɑΉ������L�����X�e�[�^�X�ύX����
            gameDirector.changeParameter(effect);            

            // �\�����b�Z�[�W�i���x���A�b�v�������j
            if (lvUpMsg != null) { msg = new string[] { actionMsg, effect.getPlusMsg(), effect.getMinusMsg(), lvUpMsg }; doLvUp = (int)actionName; }
            else msg = new string[] { actionMsg, effect.getPlusMsg(), effect.getMinusMsg() };
        }
        else    // �s�����s����
        {
            // ���Ԍo�߁B�̗́A�D���x���Z
            effect = new Effect(5, -20, 0, 0, 0, -3);
            // �G�t�F�N�g�̃p�����[�^�ɑΉ������L�����X�e�[�^�X�ύX����
            gameDirector.changeParameter(effect);
            actionMsg = "�s���Ɏ��s����";
            // �\�����b�Z�[�W
            msg = new string[] { actionMsg, effect.getPlusMsg(), effect.getMinusMsg() };
        }
        // ���b�Z�[�W���_�C�A���O�ɕ\��
        dialogManager.showDialog(msg);
    }

    public void endGame() {
        gameDirector.toEnding();
    }
}
