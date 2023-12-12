using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_MeetProfessor : RandomEvent
{
    // 教授と出会うイベント
    public Random_MeetProfessor()
    {
        id = 1;
    }
    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        Effect result = new Effect();
        msg = new List<string>() { "教授と出会った" };
        if (chara.getFriendly() >= 25)
        {
            result.friendly = 10;
            msg.Add("有効な関係を築けているようだね。");
            msg.Add("これからも育成に励むように。");
        }
        else
        {
            result.friendly = -10;
            msg.Add("この植物は君のことをあまり好いていないようだ。");
            msg.Add("もっとなつかせてみてはどうだい。");
        }
        return result;
    }
}
