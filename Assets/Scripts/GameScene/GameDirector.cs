using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // キャラ
    int currentDay;                         // 今の日数（N日目）
    int currentHour;                        // 今の時間（N時(0 ~ 23)）
    const int maxHour = 23;                 // 時間上限
    const int totalDay = 28;                // 日数上限
    [SerializeField] Text statusText;       // ステータスのテキスト
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
        return $"{currentDay}日目\n{currentHour}時";
    }

    public void addTime(int hour) {
        currentHour += hour;
        if (currentHour > 23) {
            currentHour -= 24;
            currentDay++;
        }
    }
}
