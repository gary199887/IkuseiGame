using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Contest : RandomEvent
{
    public Random_Contest(){
        id = 4;
    }
    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        Effect result = new Effect();
        msg = new List<string>() { "コンテストに出場した！" };
        int totalStatus = chara.getPower() + chara.getIntelligent() + chara.getMental();
        if (totalStatus >= GameDirector.currentDay * 55)
        {
            result.power = 5;
            result.intelligent = 5;
            result.mental = 5;
            msg.Add("最優秀賞を取った");
        }
        else if (totalStatus >= GameDirector.currentDay * 45)
        {
            result.power = 3;
            result.intelligent = 3;
            result.mental = 3;
            msg.Add("一応入賞したそうだ");
        }
        else {
            result.power = -3;
            result.intelligent = -3;
            result.mental = -3;
            msg.Add("残念ながら未入賞だった");
        }
        return result;
    }
}
