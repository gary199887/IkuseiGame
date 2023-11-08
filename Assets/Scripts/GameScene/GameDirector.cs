using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // �L����
    int currentDay;                         // ���̓����iN���ځj
    int currentHour;                        // ���̎��ԁiN��(0 ~ 23)�j
    const int totalDay = 28;                // �������
    [SerializeField] Text statusText;       // �X�e�[�^�X�̃e�L�X�g
    
    void Start()
    {
        chara = new Chara();
        currentDay = 1;
        currentHour = 8;
        changeParameter(new Effect());
    }

    void Update()
    {
        
    }

    public static void changeParameter(Effect effect) {
        chara.doEffect(effect);
    }

    public void revealStatusChangeInUI() {
        statusText.text = chara.getShowingStatus();
    }
}
