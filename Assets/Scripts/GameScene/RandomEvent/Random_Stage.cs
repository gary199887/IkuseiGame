using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Stage : RandomEvent
{
    public Random_Stage() {
        id = 7;
    }

    public override Effect doSomething(Chara chara, Action[] actions)
    {
        Effect result = new Effect();
        int actionLv = actions[2].getLv();
        msg.Add("舞台に出演した");
        if (chara.getMental() >= (2 * actionLv + GameDirector.currentDay) * 25)
        {
            result.mental = 5 * actionLv;
            msg.Add("初めてなのにまるでベテランのような落ち着きようだ");
        }
        else if (chara.getMental() >= (2 * actionLv + GameDirector.currentDay / 4 * 3) * 25)
        {
            result.mental = 3 * actionLv;
            msg.Add("木Gの役をやらせた");
            msg.Add("全然セリフないのでのでちょっと退屈だった");
        }
        else
        {
            result.mental = -3 * actionLv;
            msg.Add("下手すぎてSNSで炎上した");
        }
        return result;
    }
}
