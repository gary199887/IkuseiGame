using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // �L����
    public static bool gameOver;            // gameOver flag
    public static int currentDay;           // ���̓����iN���ځj
    public static int currentHour;          // ���̎��ԁiN��(0 ~ 23)�j
    const int maxHour = 23;                 // ���ԏ��
    const int maxDay = 28;                  // �������
    bool randomEventHappended;              // �����_���C�x���g�������������ǂ���(false������������)
    public static bool loadGame = false;
    [SerializeField] Text statusText;       // �X�e�[�^�X��UI�e�L�X�g
    [SerializeField] Text timeText;         // ������UI�e�L�X�g
    [SerializeField] Text friendlyText;     // �f�o�b�O�p�D���x�\��
    [SerializeField] Text actionTimeText;   // �f�o�b�O�p�s���񐔕\��
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] HintManager hintManager;
    [SerializeField] FixedEventManager fixedEventManager;
    [SerializeField] RandomEventManager randomEventManager;
    [SerializeField] GameObject debugButtons;
    [SerializeField] LoadManager loadManager;
    int cheatButtonClickedTime;
    float timeCount;

    void Start()
    {
        chara = new Chara();
        currentDay = 1;
        currentHour = 8;
        gameOver = false;
        //changeParameter(new Effect());
        revealStatusInUI();
        revealTimeUI();
        actionSelector.effect = null;
        randomEventHappended = true;
        debugButtons.SetActive(false);
        cheatButtonClickedTime = 0;
        timeCount = 0;
        friendlyText.text = $"{chara.getFriendly()}";
        actionTimeText.text = "�s���񐔁F��0�@��0�@��0�@�b0�@�O0�@��0";

        // load json files
        FixedEventList fixedEventList = FixedEventIO.loadFixedEvent();
        FixedEventManager.setFixedEvent(fixedEventList);

        EndingList endingList = EndingIO.loadEnding();
        EndingManager.setEngindList(endingList);

        OutingEventList outingEventList = OutingEventDataIO.LoadOutingEvent();
        OutingEventManager.SetOutingEvent(outingEventList);
    }

    void Update()
    {
        CommonFunctions.endGameWithEsc();
        if (loadGame) {
            actionSelector.effect = new Effect();
            loadManager.load();
            friendlyText.text = $"{chara.getFriendly()}";
            debugChangeActionTimes();
            Debug.Log("gameloaded");

            loadGame = false;
        }

        // "C"�L�[�O��A�łŃf�o�b�O�{�^���o��/����
        if (cheatButtonClickedTime > 0) timeCount += Time.deltaTime;
        if (timeCount > 0.7f) {
            cheatButtonClickedTime = 0;
            timeCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            cheatButtonClickedTime++;
            timeCount = 0;
            if (cheatButtonClickedTime >= 3) {
                cheatButtonClickedTime = 0;
                debugButtons.SetActive(!debugButtons.activeSelf);
            }
        }
    }

    public void changeParameter(Effect effect) {
        chara.doEffect(effect);
        friendlyText.text = $"{chara.getFriendly()}";
        hintManager.showEffectHint(effect);
    }

    public void revealStatusInUI() {
        statusText.text = chara.getShowingStatus();
        hintManager.closeEffectHint();
    }
    public void revealTimeUI() {
        timeText.text = getTimeString();
    }

    string getTimeString() {
        return $"{currentDay}����\n{currentHour}��";
    }

    // ���Ԃ̉��Z
    public bool addTime(int hour) {
        currentHour += hour;
        // �����ς�鏈��
        if (currentHour > maxHour) {
            currentHour -= 24;
            currentDay++;
            // �����ς����28���𒴂��鏈��
            if (currentDay > maxDay)
            {
                revealTimeUI();
                showEndMsg();
                return false;
            }
            // �����ς�鎞�̉e������(4���Ԍo�߁AHP20��)
            actionSelector.effect = new Effect(4, 20);

            if (currentDay % 7 == 1) {  // �Œ�C�x���g�����i7���ځ`8���ځA14���ځ`15���ځA21���ځ`22���ځj
                fixedEventManager.occurFixedEvent(currentDay);
            }
            else {
                dialogManager.showDialog(new string[] { "�����ς����", "4���ԋx�e����..." });
            }

            if (currentDay % 4 == 0 && currentDay < maxDay) {   // �����_���C�x���g�̔������i4���ځA8���ځA12���ځA16���ځA20���ځA24���ځj
                randomEventHappended = false;
            }

            changeParameter(actionSelector.effect);

            return true;
        }

        if (!randomEventHappended)      // ���������_���C�x���g�������������Afalse���C�x���g�����Atrue����
        {
            randomEventManager.occurRandomEvent();
            randomEventHappended = true;
            return true;
        }
        return false;
    }

    // �G���h���b�Z�[�W�\��
    void showEndMsg() {
        string[] endMsg = new string[] { "28���𒴂�������", "�琬���ԏI���ł�", "�}�E�X�N���b�N�Ń��U���g��ʂ�" };
        gameOver = true;
        dialogManager.showDialog(endMsg);
    }
    public void showStartMsg() {
        string[] startMsg = new string[] { "��������[�~�ŋ�������\n��̐A������������B", "�ꂩ�����x�ő��l��\n��ɐ�������炵���B", "�u�F�X�������āA\n�����Ȏp�������o���Ă���v", "���������킯�ŁA\n��̐A��Seed����Ă邱�ƂɂȂ����B" };
        dialogManager.showDialog(startMsg);
    }

    public void toEnding() {
        // �G���f�B���O�֑J�ڂ��鏈���i�G���f�B���O�I�𖢎����A���̃G���f�B���O�ő����Ă�j
        ResultDirector.ending = EndingManager.chooseEnding(chara, ActionSelector.actions);
        EndingManager.saveEndingList();
        SceneManager.LoadScene("ResultScene");
    }

    public void showLoadMsg() {
        string[] startMsg = new string[] {"�Q�[�������[�h����܂���" };
        dialogManager.showDialog(startMsg);
    }


    // �ȉ��̓f�o�b�O�p���\�b�h
    // ����o��
    public void debugDayPass()
    {
        currentDay += 1;
        actionSelector.effect = new Effect();
        dialogManager.showDialog(new string[] { "1���o�߂��܂���" });
    }

    // �X�e�[�^�X�̉��Z/���Z
    public void debugStatus(int status, int mode, int value)
    {
        Effect effect = new Effect();
        switch (status) {
            // status : 0->�D���x   1->�ؗ�   2->�m��   3->�����^��   4->HP
            // mode:    0->���Z   0�ȊO->���Z
            // value:   ���Z/���Z����l
            case 0:
                if (mode == 0)
                    effect.friendly = value;
                else
                    effect.friendly = -value;
                break;
            case 1:
                if (mode == 0)
                    effect.power = value;
                else
                    effect.power = -value;
                break;
            case 2:
                if(mode == 0)
                    effect.intelligent = value;
                else
                    effect.intelligent= -value;
                break;
            case 3:
                if (mode == 0)
                    effect.mental = value;
                else
                    effect.mental = -value;
                break;
            case 4:
                if(mode == 0)
                    effect.hp = value;
                else
                    effect.hp = -value;
                break;
        }

        // �e����K�p
        actionSelector.effect = effect;
        changeParameter(effect);
        dialogManager.showDialog(new string[] { effect.getPlusMsg(), effect.getMinusMsg() });
    }

    // �X�e�[�^�X���ω�
    public void debugStatusAverage() {
        // �ؗ́A�m�́A�����^���̕��ρi�����͐؂�̂āj
        int statusAverage = (chara.getPower() + chara.getIntelligent() + chara.getMental()) / 3;
        // �L������ڕW�̋ψ�X�e�[�^�X�ɂȂ�悤�ȉe��
        Effect effect = Effect.statusToTargetChara(chara, new Chara(0, statusAverage, statusAverage, statusAverage, 0));
        // �e����K�p
        actionSelector.effect = effect;
        changeParameter(effect);
        dialogManager.showDialog(new string[] { "�X�e�[�^�X�͕��ω����ꂽ" });
    }

    public void debugChangeActionTimes() {
        Action[] actions = ActionSelector.actions;
        string text = $"�s���񐔁F��{actions[5].times}�@��{actions[0].times}�@��{actions[1].times}�@�b{actions[2].times}�@�O{actions[3].times}�@��{actions[4].times}";
        actionTimeText.text = text;
    }
}
