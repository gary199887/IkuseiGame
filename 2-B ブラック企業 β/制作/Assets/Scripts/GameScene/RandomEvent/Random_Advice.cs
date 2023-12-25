using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Advice : RandomEvent
{
    // アドバイスイベント
    private List<string> advice = new List<string>();
    
    public Random_Advice() 
    {
        id = 2;
        advice.Add("もっと筋力を伸ばしてみたらどうかな");
        advice.Add("もっと知力を伸ばしてみたらどうかな");
        advice.Add("もっとメンタルを伸ばしてみたらどうかな");
        advice.Add("ステータスを均一にしてみるのもいいかもしれない");
        advice.Add("もっとなつかせてみたらどうかな");
    }
    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        msg = new List<string>() { GameDirector.currentDay + "日が経過した" };
        int adviceNum = Random.Range(0, advice.Count);
        msg.Add(advice[adviceNum]);
        return new Effect();
    }
}
