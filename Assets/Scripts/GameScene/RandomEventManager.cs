using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    [SerializeField] GameDirector gameDirector;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] DialogManager dialogManager;
    List<RandomEvent> randomEvents;             // 発生予定ランダムイベントバッファー

    private void Start()
    {
        // 各種ランダムイベントをバッファーに追加
        randomEvents = new List<RandomEvent>{ new Random_Contest() };
    }
    // ランダムイベント発生
    public void occurRandomEvent() {
        // バッファーにランダムイベントが残っている場合
        if (randomEvents.Count > 0)
        {   // 発生しているイベントをバッファーからランダムで決める 
            RandomEvent happeningEvent = randomEvents[Random.Range(0, randomEvents.Count)];

            // イベント発生処理（影響を得る、メッセージを改変）
            Effect effect = happeningEvent.doSomething(GameDirector.chara, ActionSelector.actions);
            // イベントから結果に応じたメッセージを取得
            List<string>msg = new List<string>(happeningEvent.msg);
            // 影響を代入
            actionSelector.effect = effect;
            // 影響をパラメータに適用
            gameDirector.changeParameter(actionSelector.effect);
            
            // メッセージにエフェクトに応じた上昇、降下項目を追加
            msg.Add(effect.getPlusMsg());
            msg.Add(effect.getMinusMsg());
            // メッセージを表示
            dialogManager.showDialog(msg.ToArray());
            
            // 発生したイベントをバッファーから削除
            randomEvents.Remove(happeningEvent);
        }  
    }
}
