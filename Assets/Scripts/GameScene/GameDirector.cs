using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // �L����
    public static bool gameOver;            // gameOver flag
    public static int currentDay;           // ���̓����iN���ځj
    public static int currentHour;          // ���̎��ԁiN��(0 ~ 23)�j
    const int maxHour = 23;                 // ���ԏ��
    const int maxDay = 28;                  // �������
    bool randomEventHappended;              // �����_���C�x���g�������������ǂ���(false������������)
    [SerializeField] Text statusText;       // �X�e�[�^�X��UI�e�L�X�g
    [SerializeField] Text timeText;         // ������UI�e�L�X�g
    [SerializeField] Text friendlyText;     // �f�o�b�O�p�D���x�\��
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] HintManager hintManager;
    [SerializeField] FixedEventManager fixedEventManager;
    [SerializeField] RandomEventManager randomEventManager;
    
    void Start()
    {
        chara = new Chara();
        currentDay = 1;
        currentHour = 8;
        gameOver = false;
        changeParameter(new Effect());
        revealStatusInUI();
        revealTimeUI();
        actionSelector.effect = null;
        randomEventHappended = true;
        FixedEventList fixedEventList = FixedEventIO.loadFixedEvent();
        
        FixedEventManager.setFixedEvent(fixedEventList);
       
    }

    void Update()
    {
        CommonFunctions.endGameWithEsc();
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

            if (currentDay % 4 == 0 && currentDay < maxDay){   // �����_���C�x���g�̔������i4���ځA8���ځA12���ځA16���ځA20���ځA24���ځj
                randomEventHappended = false;
            }

            changeParameter(actionSelector.effect);
           
            return true;
        }

        if (!randomEventHappended && currentHour >= 12)      // ���������_���C�x���g�������������Afalse���C�x���g�����Atrue����
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
        string[] startMsg = new string[] { "The Seed�̐��E�ւ悤����" , "���������28���Ԃœ�̐A������Ă܂�", "�F�X�������āA�l�X�Ȍ��ʂ��W�߂܂��傤" };
        dialogManager.showDialog(startMsg);
    }

    public void toEnding() {
        // �G���f�B���O�֑J�ڂ��鏈���i�G���f�B���O�I�𖢎����A���̃G���f�B���O�ő����Ă�j
        ResultDirector.ending = EndingManager.chooseEnding(chara);
        Debug.Log(EndingManager.endingList[0].cleared);
        SceneManager.LoadScene("ResultScene");
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
            // status : 0->�D���x   1->�ؗ�   2->�m��   3->�����^��
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

}
