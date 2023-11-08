using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // キャラ
    int currentDay;                         // 今の日数（N日目）
    int currentHour;                        // 今の時間（N時(0 ~ 23)）
    const int totalDay = 28;                // 日数上限
    [SerializeField] Text statusText;       // ステータスのテキスト
    
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
