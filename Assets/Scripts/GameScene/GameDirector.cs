using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    Chara chara;                // �L����
    int currentDay;             // ���̓����iN���ځj
    int currentHour;            // ���̎��ԁiN��(0 ~ 23)�j
    const int totalDay = 28;    // �������
    
    void Start()
    {
        chara = new Chara();
        currentDay = 1;
        currentHour = 8;
    }

    void Update()
    {
        
    }
}
