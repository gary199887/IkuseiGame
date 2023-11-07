using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;
    [SerializeField] GameObject buttons;
    public void onWateringButtonClicked() {     // 例として水やりボタンがクリックされた時呼び出す空メソッド
        closeButtons();
        string[] msg = { "水やりをした" };
        dialogManager.showDialog(msg);
    }


    public void onThrowingButtonClicked() {     // 
    
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

}
