using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // �L����
    public static bool gameOver;            // gameOver flag
    int currentDay;                         // ���̓����iN���ځj
    int currentHour;                        // ���̎��ԁiN��(0 ~ 23)�j
    const int maxHour = 23;                 // ���ԏ��
    const int maxDay = 28;                  // �������
    [SerializeField] Text statusText;       // �X�e�[�^�X��UI�e�L�X�g
    [SerializeField] Text timeText;         // ������UI�e�L�X�g
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] HintManager hintManager;
    
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
    }

    void Update()
    {
        
    }

    public void changeParameter(Effect effect) {
        chara.doEffect(effect);
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
        if (currentHour > maxHour) {
            currentHour -= 24;
            currentDay++;
            if (currentDay > maxDay)
            {
                revealTimeUI();
                showEndMsg();
                return false;
            }
            actionSelector.effect = new Effect(4, 20);
            changeParameter(actionSelector.effect);
            dialogManager.showDialog(new string[] { "�����ς����" , "4���ԋx�e����..." });
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

    public void toEnding() {
        // �G���f�B���O�֑J�ڂ��鏈���i�G���f�B���O�I�𖢎����A���̃G���f�B���O�ő����Ă�j
        Ending ending = new Ending();
        ResultDirector.ending = ending;
        SceneManager.LoadScene("ResultScene");
    }

    public void debugDayPass()
    {
        currentDay = 28;
        actionSelector.effect = new Effect();
        dialogManager.showDialog(new string[] { "28���ڂɃW�����v����" });
    }
}
