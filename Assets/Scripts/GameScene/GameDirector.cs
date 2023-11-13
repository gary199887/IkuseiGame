using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditorInternal;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // �L����
    int currentDay;                         // ���̓����iN���ځj
    int currentHour;                        // ���̎��ԁiN��(0 ~ 23)�j
    const int maxHour = 23;                 // ���ԏ��
    const int maxDay = 28;                // �������
    [SerializeField] Text statusText;       // �X�e�[�^�X�̃e�L�X�g
    [SerializeField] Text timeText;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ButtonFuctions buttonFuctions;
    
    void Start()
    {
        chara = new Chara();
        currentDay = 1;
        currentHour = 8;
        changeParameter(new Effect());
        revealStatusInUI();
        revealTimeUI();
    }

    void Update()
    {
        
    }

    public static void changeParameter(Effect effect) {
        chara.doEffect(effect);
    }

    public void revealStatusInUI() {
        statusText.text = chara.getShowingStatus();
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
                toEnding();
                return false;
            }
            buttonFuctions.effect = new Effect(4,0,0,0,0,0);
            dialogManager.showDialog(new string[] { "4���ԋx�e����..." });
            return true;
        }
        
        return false;
    }

    public void toEnding() {
        // �G���f�B���O�֑J�ڂ��鏈���i�������j
    }
}
