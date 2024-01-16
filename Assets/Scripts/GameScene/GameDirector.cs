using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    public static Chara chara;              // キャラ
    public static bool gameOver;            // gameOver flag
    public static int currentDay;           // 今の日数（N日目）
    public static int currentHour;          // 今の時間（N時(0 ~ 23)）
    const int maxHour = 23;                 // 時間上限
    const int maxDay = 28;                  // 日数上限
    bool randomEventHappended;              // ランダムイベントが発生したかどうか(false時発生させる)
    public static bool loadGame = false;
    [SerializeField] Text statusText;       // ステータスのUIテキスト
    [SerializeField] Text timeText;         // 日時のUIテキスト
    [SerializeField] Text friendlyText;     // デバッグ用好感度表示
    [SerializeField] Text actionTimeText;   // デバッグ用行動回数表示
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] HintManager hintManager;
    [SerializeField] FixedEventManager fixedEventManager;
    [SerializeField] RandomEventManager randomEventManager;
    [SerializeField] GameObject debugButtons;
    [SerializeField] LoadManager loadManager;
    int cheatButtonClickedTime;
    float timeCount;

    void Start()
    {
        chara = new Chara();
        currentDay = 1;
        currentHour = 8;
        gameOver = false;
        //changeParameter(new Effect());
        revealStatusInUI();
        revealTimeUI();
        actionSelector.effect = null;
        randomEventHappended = true;
        debugButtons.SetActive(false);
        cheatButtonClickedTime = 0;
        timeCount = 0;
        friendlyText.text = $"{chara.getFriendly()}";
        actionTimeText.text = "行動回数：水0　投0　勉0　話0　外0　薬0";

        // load json files
        FixedEventList fixedEventList = FixedEventIO.loadFixedEvent();
        FixedEventManager.setFixedEvent(fixedEventList);

        EndingList endingList = EndingIO.loadEnding();
        EndingManager.setEngindList(endingList);

        OutingEventList outingEventList = OutingEventDataIO.LoadOutingEvent();
        OutingEventManager.SetOutingEvent(outingEventList);
    }

    void Update()
    {
        CommonFunctions.endGameWithEsc();
        if (loadGame) {
            actionSelector.effect = new Effect();
            loadManager.load();
            friendlyText.text = $"{chara.getFriendly()}";
            debugChangeActionTimes();
            Debug.Log("gameloaded");

            loadGame = false;
        }

        // "C"キー三回連打でデバッグボタン出現/消失
        if (cheatButtonClickedTime > 0) timeCount += Time.deltaTime;
        if (timeCount > 0.7f) {
            cheatButtonClickedTime = 0;
            timeCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            cheatButtonClickedTime++;
            timeCount = 0;
            if (cheatButtonClickedTime >= 3) {
                cheatButtonClickedTime = 0;
                debugButtons.SetActive(!debugButtons.activeSelf);
            }
        }
    }

    public void changeParameter(Effect effect) {
        chara.doEffect(effect);
        friendlyText.text = $"{chara.getFriendly()}";
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

            if (currentDay % 7 == 1) {  // 固定イベント発生（7日目～8日目、14日目～15日目、21日目～22日目）
                fixedEventManager.occurFixedEvent(currentDay);
            }
            else {
                dialogManager.showDialog(new string[] { "日が変わった", "4時間休憩した..." });
            }

            if (currentDay % 4 == 0 && currentDay < maxDay) {   // ランダムイベントの発生日（4日目、8日目、12日目、16日目、20日目、24日目）
                randomEventHappended = false;
            }

            changeParameter(actionSelector.effect);

            return true;
        }

        if (!randomEventHappended)      // 当日ランダムイベントが発生したか、false時イベント発生、trueを代入
        {
            randomEventManager.occurRandomEvent();
            randomEventHappended = true;
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
        string[] startMsg = new string[] { "所属するゼミで教授から\n謎の植物をもらった。", "一か月程度で多様で\n奇妙に成長するらしい。", "「色々実験して、\nいろんな姿を引き出してくれ」", "そういうわけで、\n謎の植物Seedを育てることになった。" };
        dialogManager.showDialog(startMsg);
    }

    public void toEnding() {
        // エンディングへ遷移する処理（エンディング選択未実装、仮のエンディングで送ってる）
        ResultDirector.ending = EndingManager.chooseEnding(chara, ActionSelector.actions);
        EndingManager.saveEndingList();
        SceneManager.LoadScene("ResultScene");
    }

    public void showLoadMsg() {
        string[] startMsg = new string[] {"ゲームがロードされました" };
        dialogManager.showDialog(startMsg);
    }


    // 以下はデバッグ用メソッド
    // 一日経過
    public void debugDayPass()
    {
        currentDay += 1;
        actionSelector.effect = new Effect();
        dialogManager.showDialog(new string[] { "1日経過しました" });
    }

    // ステータスの加算/減算
    public void debugStatus(int status, int mode, int value)
    {
        Effect effect = new Effect();
        switch (status) {
            // status : 0->好感度   1->筋力   2->知力   3->メンタル   4->HP
            // mode:    0->加算   0以外->減算
            // value:   加算/減算する値
            case 0:
                if (mode == 0)
                    effect.friendly = value;
                else
                    effect.friendly = -value;
                break;
            case 1:
                if (mode == 0)
                    effect.power = value;
                else
                    effect.power = -value;
                break;
            case 2:
                if(mode == 0)
                    effect.intelligent = value;
                else
                    effect.intelligent= -value;
                break;
            case 3:
                if (mode == 0)
                    effect.mental = value;
                else
                    effect.mental = -value;
                break;
            case 4:
                if(mode == 0)
                    effect.hp = value;
                else
                    effect.hp = -value;
                break;
        }

        // 影響を適用
        actionSelector.effect = effect;
        changeParameter(effect);
        dialogManager.showDialog(new string[] { effect.getPlusMsg(), effect.getMinusMsg() });
    }

    // ステータス平均化
    public void debugStatusAverage() {
        // 筋力、知力、メンタルの平均（小数は切り捨て）
        int statusAverage = (chara.getPower() + chara.getIntelligent() + chara.getMental()) / 3;
        // キャラを目標の均一ステータスになるような影響
        Effect effect = Effect.statusToTargetChara(chara, new Chara(0, statusAverage, statusAverage, statusAverage, 0));
        // 影響を適用
        actionSelector.effect = effect;
        changeParameter(effect);
        dialogManager.showDialog(new string[] { "ステータスは平均化された" });
    }

    public void debugChangeActionTimes() {
        Action[] actions = ActionSelector.actions;
        string text = $"行動回数：水{actions[5].times}　投{actions[0].times}　勉{actions[1].times}　話{actions[2].times}　外{actions[3].times}　薬{actions[4].times}";
        actionTimeText.text = text;
    }
}
