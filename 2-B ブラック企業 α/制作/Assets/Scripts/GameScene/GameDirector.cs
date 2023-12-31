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
    [SerializeField] FixedEventManager fixedEventManager;
    
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
        FixedEventList fixedEventList = FixedEventIO.loadFixedEvent();
        
        FixedEventManager.setFixedEvent(fixedEventList);
       
    }

    void Update()
    {
        CommonFunctions.endGameWithEsc();
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
        // 日が変わる処理
        if (currentHour > maxHour) {
            currentHour -= 24;
            currentDay++;
            // 日が変わって28日を超える処理
            if (currentDay > maxDay)
            {
                revealTimeUI();
                showEndMsg();
                return false;
            }
            // 日が変わる時の影響を代入(4時間経過、HP20回復)
            actionSelector.effect = new Effect(4, 20);

            if (currentDay % 7 == 1) {  // 固定イベント発生（7日目〜8日目、14日目〜15日目、21日目〜22日目）
                fixedEventManager.occurFixedEvent(currentDay);
            }
            else { 
                dialogManager.showDialog(new string[] { "日が変わった", "4時間休憩した..." });
            }


            changeParameter(actionSelector.effect);
           
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
    public void showStartMsg() {
        string[] startMsg = new string[] { "The Seedの世界へようこそ" , "ここからは四週間かかって謎の植物を育てるよ", "色々実験して", "28日目終了後のエンディングを見てみましょう" };
        dialogManager.showDialog(startMsg);
    }

    public void toEnding() {
        // エンディングへ遷移する処理（エンディング選択未実装、仮のエンディングで送ってる）
        ResultDirector.ending = EndingManager.chooseEnding(chara);
        Debug.Log(EndingManager.endingList[0].cleared);
        SceneManager.LoadScene("ResultScene");
    }

    public void debugDayPass()
    {
        currentDay += 1;
        actionSelector.effect = new Effect();
        dialogManager.showDialog(new string[] { "1日経過しました" });
    }

    
}
