using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFuctions : MonoBehaviour
{
    public void onWateringButtonClicked() {     // 例として水やりボタンがクリックされた時呼び出す空メソッド
        Debug.Log("水やりを選択した");
    }

    public void onItemButtonClicked() {        //　アイテム使用ボタンがクリックされた時呼び出すメソッド
    
    }

    public void onTalkingButtonClicked()
    {
        Debug.Log("声をかけるを選択した");
    }

    public void onOutingButtonClicked()
    {
        Debug.Log("出かけるを選択した");
    }
}
