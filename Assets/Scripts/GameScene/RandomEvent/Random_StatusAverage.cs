using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_StatusAverage : RandomEvent
{
    // ステータス平均化イベント
    public Random_StatusAverage()
    {
        id = 0;
    }

    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        Effect result = new Effect();
        msg = new List<string>() { "怪しげな実験を行った", "ステータスが平均化された" };
        // 筋力、知力、メンタルの平均（小数は切り捨て）
        int statusAverage = (chara.getPower() + chara.getIntelligent() + chara.getMental()) / 3;
        // キャラを目標の均一ステータスになるような影響
        result = Effect.statusToTargetChara(chara, new Chara(0, statusAverage, statusAverage, statusAverage, 0));
        
        return result;
    }
}
