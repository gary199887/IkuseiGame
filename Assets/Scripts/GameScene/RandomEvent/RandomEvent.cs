using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent
{
    public int id;              // 画像データ差し替え用
    public List<string> msg;    // メッセージ表示用
    // Chara, Action[]: 条件判断用(ステータス、行動Lｖ)

    public RandomEvent() {
        msg = new List<string>();
    }
    public virtual Effect doSomething(Chara chara, Action[] actions) { return null; }
}
