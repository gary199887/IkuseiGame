using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;   // ダイアログ表示用のマネージャーObj
    [SerializeField] GameObject buttons;            // ボタン全体、ボタンon/off切り替え用GameObj
    [SerializeField] GameDirector gameDirector;     // パラメーター変更用GameDirector Obj
    public Effect effect;
    public void onWateringButtonClicked() {     // 例として水やりボタンがクリックされた時呼び出すメソッド
        closeButtons();
        effect = new Effect(2, 0, 0, 1, 1);
        GameDirector.changeParameter(effect);
        string[] msg = { "水やりをした", effect.getPlusMsg() , effect.getMinusMsg() };
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // 投げつけるボタンクリックされた時に呼び出すメソッド
        closeButtons();
        effect = new Effect(-1, 3, 0, -1, -1);
        GameDirector.changeParameter(effect);
        string[] msg = {"投げつけた", effect.getPlusMsg(), effect.getMinusMsg() };
        dialogManager.showDialog(msg);
    }

    public void onStudyButtonClicked(){        // 勉強させるボタンクリックされた時に呼び出すメソッド
        closeButtons();
        effect = new Effect(-1, 0, 2, 0, 0);
        GameDirector.changeParameter(effect);
        string[] msg = {"勉強させた", effect.getPlusMsg(), effect.getMinusMsg() };
        dialogManager.showDialog(msg);
    }
    public void onItemButtonClicked() {        //　アイテム使用ボタンがクリックされた時呼び出すメソッド
        closeButtons();
        string[] msg = { "アイテムを使用した" };
        dialogManager.showDialog(msg);
    }

    public void onTalkingButtonClicked()    //　会話ボタンがクリックされた時呼び出すメソッド
    {
        closeButtons();
        string[] msg = { "話しかけた", "メンタルが上がった" };
        dialogManager.showDialog(msg);

    }

    public void onOutingButtonClicked()     //　会話ボタンがクリックされた時呼び出すメソッド
    {
        closeButtons();
        string[] msg = { "お出かけした" };
        dialogManager.showDialog(msg);
    }

    void closeButtons() { 
        buttons.SetActive(false);
    }

    public void showButtons() {
        buttons.SetActive(true);
    }

    public void afterActionDialogClosed() {
        gameDirector.revealStatusChangeInUI();
        // GameDirectorに時間の加算を追加予定

        // effectをnullに戻す
        effect = null;
    }
}
