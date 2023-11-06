using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    Chara chara;                // キャラ
    int currentDay;             // 今の日数（N日目）
    int currentHour;            // 今の時間（N時(0 ~ 23)）
    const int totalDay = 28;    // 日数上限
    
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
