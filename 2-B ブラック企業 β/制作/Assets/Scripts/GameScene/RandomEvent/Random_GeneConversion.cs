using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_GeneConversion : RandomEvent
{
    // 遺伝子変換イベント
    public Random_GeneConversion() 
    {
        id = 3;
    }
    public override Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        Effect result = new Effect();
        msg = new List<string>() { "遺伝子変換を行った" };
        int[] status = { chara.getPower(), chara.getIntelligent(), chara.getMental() };
        int max = status[0];
        int min = status[0];
        int maxIndex = 0;
        int minIndex = 0;

        for (int i = 1; i < status.Length; ++i) {
            if (status[i] > max)
            {
                max = status[i];
                maxIndex = i;
            }
            else if (status[i] < min) {
                min = status[i];
                minIndex = i;
            }
        }
        if(max == min)
        {
            msg.Add("何も起こらなかった");
            return result;
        }
        msg.Add("高いステータスと低いステータスが入れ替わった");
        status[maxIndex] = min;
        status[minIndex] = max;
        Chara target = new Chara(0, status[0], status[1], status[2], 0);
        result = Effect.statusToTargetChara(chara, target);
        return result;
    }
}
