using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;   // ダイアログ表示用のマネージャーObj
    [SerializeField] GameObject buttons;            // ボタン全体、ボタンon/off切り替え用GameObj
    [SerializeField] GameDirector gameDirector;     // パラメーター変更用GameDirector Obj
    public Effect effect;                           // 行動に起こされた変化
    Action[] actions = {new Action("Throw"), new Action("Study"), new Action("Talk")};  // 行動Lv計算用(投げつけ、勉強、話しかける)

    public void onWateringButtonClicked() {     // 水やりボタンがクリックされた時呼び出すメソッド
        closeButtons();
        string[] msg;
       
        effect = new Effect(3, 30, 0, 0, 1, 1);
        GameDirector.changeParameter(effect);
        msg = new string[] { "水やりをした", effect.getPlusMsg(), effect.getMinusMsg()};
       
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // 投げつけるボタンクリックされた時に呼び出すメソッド
        string[] msg;
        if (getSuccessOrNot(GameDirector.chara.getHp() + 20))   // キャラのHPに応じて行動成功/失敗判定　20（基礎成功率）+ キャラHP (0 ~ 100)
        {
            // 行動lvに応じて変化する値(power)が変動  5（基礎値） + 30 x 行動lv(1 ~ 5) / 5
            effect = new Effect(3, -30, 5 + (int)Mathf.Ceil(30 * ((float)actions[0].getLv() / 5)), 0, 0, 0);
            // 行動回数追加、レベルアップチェック
            string lvUpMsg = actions[0].doAction();
            // エフェクトのパラメータに対応したキャラステータス変更処理
            GameDirector.changeParameter(effect);

            // 表示メッセージ（レベルアップしたか）
            if (lvUpMsg != null) msg = new string[] { "投げつけた", effect.getPlusMsg(), effect.getMinusMsg(), lvUpMsg };
            else msg = new string[] { "投げつけた", effect.getPlusMsg(), effect.getMinusMsg() };
        }
        else    // 行動失敗処理
        {
            // 時間経過。体力、好感度減算
            effect = new Effect(3, -20, 0, 0, 0, -2);
            // エフェクトのパラメータに対応したキャラステータス変更処理
            GameDirector.changeParameter(effect);
            // 表示メッセージ
            msg = new string[] { "行動に失敗した", effect.getPlusMsg(), effect.getMinusMsg() };
        }
        // メッセージをダイアログに表示
        dialogManager.showDialog(msg);
    }

    public void onStudyButtonClicked(){        // 勉強させるボタンクリックされた時に呼び出すメソッド
        effect = new Effect(3, -30, 0, 30, 0, 0);
        GameDirector.changeParameter(effect);
        string[] msg = {"勉強させた", effect.getPlusMsg(), effect.getMinusMsg() };
        dialogManager.showDialog(msg);
    }
    public void onItemButtonClicked() {        //　アイテム使用ボタンがクリックされた時呼び出すメソッド
        string[] msg = { "アイテムを使用した" };
        dialogManager.showDialog(msg);
    }

    public void onTalkingButtonClicked()    //　会話ボタンがクリックされた時呼び出すメソッド
    {
        effect = new Effect(3, -30, 0, 0, 30, 0);
        GameDirector.changeParameter(effect);
        string[] msg = { "話しかけた", effect.getPlusMsg(), effect.getMinusMsg() };
        dialogManager.showDialog(msg);

    }

    public void onOutingButtonClicked()     //　会話ボタンがクリックされた時呼び出すメソッド
    {
        // イベント発生処理追加予定
        string[] msg = { "お出かけした" };
        dialogManager.showDialog(msg);
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
}
