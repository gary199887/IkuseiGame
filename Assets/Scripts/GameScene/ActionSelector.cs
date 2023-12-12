using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionSelector : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;   // ダイアログ表示用のマネージャーObj
    [SerializeField] GameObject buttons;            // ボタン全体、ボタンon/off切り替え用GameObj
    [SerializeField] GameDirector gameDirector;     // パラメーター変更用GameDirector Obj
    [SerializeField] HintManager hintManager;
    [SerializeField] OutingEventManager outingEventManager;     // 外出イベント用マネージャーobj
    public Effect effect;                           // 行動に起こされた変化
    enum actionWithLv { 投げつける, 勉強させる, 話しかける };      // 行動レベルのある行動名(失敗する可能性がある)
    public static Action[] actions;  // 行動Lv計算用(投げつけ、勉強、話しかける)
    int doLvUp;         // 行動レベルアップする際に使用される（index）

    void Start()
    {
        effect = null;
        actions = new Action[]{ new Action("Throw"), new Action("Study"), new Action("Talk"), new Action("Out"), new Action("Medicine")};
        doLvUp = -1;
    }
    public void onWateringButtonClicked() {     // 水やりボタンがクリックされた時呼び出すメソッド
        closeButtons();
        string[] msg;
       
        effect = new Effect(5, 30, 0, 0, 0, 1);
        gameDirector.changeParameter(effect);
        msg = new string[] { "水やりをした", effect.getPlusMsg(), effect.getMinusMsg()};
       
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // 投げつけるボタンクリックされた時に呼び出すメソッド
        doActionWithLv(actionWithLv.投げつける);
    }

    public void onStudyButtonClicked(){        // 勉強させるボタンクリックされた時に呼び出すメソッド
        doActionWithLv(actionWithLv.勉強させる);
    }
    public void onItemButtonClicked() {        //　アイテム使用ボタンがクリックされた時呼び出すメソッド
        string successOrNot = "";
        if (getSuccessOrNot(50))
        {
            successOrNot = "効果はバツグンのようだ！";
            effect = new Effect(7, -10, 30, 30, 30, -10);
        }
        else
        {
            successOrNot = "まずい、注入した薬が逆作用を起こしたようだ！";
            effect = new Effect(7, -30, -30, -30, -30, -20);
        }
        gameDirector.changeParameter(effect);
        string[] msg = { "変な薬を注入した", successOrNot, effect.getPlusMsg(), effect.getMinusMsg()};
        dialogManager.showDialog(msg);
        actions[4].times++;
    }

    public void onTalkingButtonClicked()    //　会話ボタンがクリックされた時呼び出すメソッド
    {
        doActionWithLv(actionWithLv.話しかける);
    }

    public void onOutingButtonClicked()     //　外出ボタンがクリックされた時呼び出すメソッド
    {
        // イベント発生処理追加予定
        OutingEventList eventsData = OutingEventManager.LoadEvents();
        int eventNum = Random.Range(0, eventsData.events.Count);    // イベント数に応じてランダム
        
        effect = eventsData.events[eventNum].effect;
        gameDirector.changeParameter(effect);

        string[] msg1 = eventsData.events[eventNum].msg;
        string[] msg2 = { effect.getPlusMsg(), effect.getMinusMsg() };
        string[] msg = msg1.Concat(msg2).ToArray();  // 配列の結合
        dialogManager.showDialog(msg);
        outingEventManager.ShowOutingEvent(eventNum);
        actions[3].times++;
    }

    // 行動選択ボタンを消す
    public void closeButtons() { 
        buttons.SetActive(false);
    }

    // 行動選択ボタンを戻す
    public void showButtons() {
        buttons.SetActive(true);
    }

    // 行動選択後のダイアログ閉じる時に呼び出すメソッド
    public void afterActionDialogClosed() {
        gameDirector.revealStatusInUI();

        if (doLvUp > -1) {  // レベルアップしたかどうか
            // アップした行動レベルをUI上に反映
            hintManager.lvUpInUI(doLvUp, actions[doLvUp].getLv());
            // 判断用の変数を-1に戻す
            doLvUp = -1;
        }

        // 成功率をUIに反映
        for(int i = 0; i < 3; ++i)
            hintManager.successChangeInUI(i, getSuccessPercentage(i));

        // 時間加算  日数経過がある場合はtrue 
        if (!gameDirector.addTime(effect.time))     // 日数が経過しなかった場合（or エンディングに進む場合）
            effect = null;                          // effectをnullに戻す

        // 時間をUIに反映
        gameDirector.revealTimeUI();
    }

    // 抽選（パーセンテージ）メソッド
    bool getSuccessOrNot(int percentage) {
        if(Random.Range(1, 101) <= percentage)
            return true;
        return false;
    }

    // 行動ごとの成功率を取得するメソッド
    int getSuccessPercentage(int actionId)
    {
        // 基礎値　5 + HP + 行動レベル + 好感度
        return Mathf.Clamp(5 + GameDirector.chara.getHp() + actions[actionId].getLv() * 2 + GameDirector.chara.getFriendly(), 0, 100);
    }

    // 失敗することがある行動をとる時に呼び出すメソッド
    void doActionWithLv(actionWithLv actionName) {
        string[] msg;           // ダイアログに表示されるメッセージ
        string actionMsg = "";  // 行動別に変わる最初のメッセージ
        if (getSuccessOrNot(getSuccessPercentage((int) actionName)))   // キャラのHPに応じて行動成功/失敗判定　5（基礎成功率）+ キャラHP (0 ~ 100) + 行動レベル(1~5) * 5
        {
            // 行動lvに応じて変化する値が変動 30 x 行動lv(1 ~ 5) / 5
            effect = new Effect();
            effect.time = 5;
            effect.hp = -30;
            int changeValue = (int)Mathf.Ceil(30 * ((float)actions[(int)actionName].getLv() / 5));
            switch (actionName) {
                case actionWithLv.投げつける:
                    effect.power = changeValue;
                    actionMsg = "投げつけた";
                    break;
                case actionWithLv.勉強させる:
                    effect.intelligent = changeValue;
                    actionMsg = "勉強させた";
                    break;
                case actionWithLv.話しかける:
                    effect.mental = changeValue;
                    actionMsg = "話しかけた";
                    break;
            }


            // 行動回数追加、レベルアップチェック
            string lvUpMsg = actions[(int)actionName].doAction();
            // エフェクトのパラメータに対応したキャラステータス変更処理
            gameDirector.changeParameter(effect);            

            // 表示メッセージ（レベルアップしたか）
            if (lvUpMsg != null) { msg = new string[] { actionMsg, effect.getPlusMsg(), effect.getMinusMsg(), lvUpMsg }; doLvUp = (int)actionName; }
            else msg = new string[] { actionMsg, effect.getPlusMsg(), effect.getMinusMsg() };
        }
        else    // 行動失敗処理
        {
            // 時間経過。体力、好感度減算
            effect = new Effect(3, -20, 0, 0, 0, 0);
            // エフェクトのパラメータに対応したキャラステータス変更処理
            gameDirector.changeParameter(effect);
            actionMsg = "行動に失敗した";
            // 表示メッセージ
            msg = new string[] { actionMsg, effect.getPlusMsg(), effect.getMinusMsg() };
        }
        // メッセージをダイアログに表示
        dialogManager.showDialog(msg);
    }

    public void endGame() {
        gameDirector.toEnding();
    }
}
