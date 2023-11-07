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
        string[] msg = { "水やりをした", effect.toPlusString() };
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // 投げつけるボタンクリックされた時に呼び出すメソッド
        closeButtons();
        effect = new Effect(-1, 3, 0, -1, -1);
        string[] msg = {"投げつけた", effect.toPlusString()};
        dialogManager.showDialog(msg);
    }

    public void onStudyButtonClicked() {
        closeButtons();
        effect = new Effect(-1, 0, 2, 0, 0);
        string[] msg = {"勉強させた", effect.toPlusString()};
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

    public void changeParameters() {
        gameDirector.changeParameter(effect);
        effect = null;
    }
}
