using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // �L����
    int currentDay;                         // ���̓����iN���ځj
    int currentHour;                        // ���̎��ԁiN��(0 ~ 23)�j
    const int maxHour = 23;                 // ���ԏ��
    const int totalDay = 28;                // �������
    [SerializeField] Text statusText;       // �X�e�[�^�X�̃e�L�X�g
    [SerializeField] Text timeText;
    
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

    public void addTime(int hour) {
        currentHour += hour;
        if (currentHour > 23) {
            currentHour -= 24;
            currentDay++;
        }
    }
}
