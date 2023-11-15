using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditorInternal;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // キャラ
    int currentDay;                         // 今の日数（N日目）
    int currentHour;                        // 今の時間（N時(0 ~ 23)）
    const int maxHour = 23;                 // 時間上限
    const int maxDay = 28;                // 日数上限
    [SerializeField] Text statusText;       // ステータスのテキスト
    [SerializeField] Text timeText;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ButtonFunctions buttonFuctions;
    [SerializeField] HintManager hintManager;
    
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
        return $"{currentDay}日目\n{currentHour}時";
    }

    // 時間の加算
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
            buttonFuctions.effect = new Effect(4, 20);
            changeParameter(buttonFuctions.effect);
            dialogManager.showDialog(new string[] { "日が変わった" , "4時間休憩した..." });
            return true;
        }
        
        return false;
    }

    public void toEnding() {
        // エンディングへ遷移する処理（未実装）
    }
}
