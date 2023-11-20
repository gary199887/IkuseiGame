using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // キャラ
    public static bool gameOver;            // gameOver flag
    int currentDay;                         // 今の日数（N日目）
    int currentHour;                        // 今の時間（N時(0 ~ 23)）
    const int maxHour = 23;                 // 時間上限
    const int maxDay = 28;                  // 日数上限
    [SerializeField] Text statusText;       // ステータスのUIテキスト
    [SerializeField] Text timeText;         // 日時のUIテキスト
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
                showEndMsg();
                return false;
            }
            actionSelector.effect = new Effect(4, 20);
            changeParameter(actionSelector.effect);
            dialogManager.showDialog(new string[] { "日が変わった" , "4時間休憩した..." });
            return true;
        }
        
        return false;
    }

    // エンドメッセージ表示
    void showEndMsg() {
        string[] endMsg = new string[] { "28日を超えたため", "育成期間終了です", "マウスクリックでリザルト画面へ" };
        gameOver = true;
        dialogManager.showDialog(endMsg);
    }

    public void toEnding() {
        // エンディングへ遷移する処理（エンディング選択未実装、仮のエンディングで送ってる）
        Ending ending = new Ending();
        ResultDirector.ending = ending;
        SceneManager.LoadScene("ResultScene");
    }

    public void debugDayPass()
    {
        currentDay = 28;
        actionSelector.effect = new Effect();
        dialogManager.showDialog(new string[] { "28日目にジャンプした" });
    }
}
