

public class Random_Puzzle : RandomEvent
{
    public Random_Puzzle() {
        id = 5;
    }

    public override Effect doSomething(Chara chara, Action[] actions)
    {
        Effect result = new Effect();
        int actionLv = actions[1].getLv();
        msg.Add("パズルを解いてみた");
        if (chara.getIntelligent() >= (2 * actionLv + GameDirector.currentDay) * 25)
        {
            result.intelligent = 5 * actionLv;
            msg.Add("す、、すごい！ほとんど時間かからなかった！");
        }
        else if (chara.getIntelligent() >= (2 * actionLv + GameDirector.currentDay / 4 * 3) * 25)
        {
            result.intelligent = 3 * actionLv;
            msg.Add("それなりに時間かかった");
        }
        else {
            result.intelligent = -3 * actionLv;
            msg.Add("全然解けなかった");
        }
        return result;
    }
}
