
public class Random_StaminaTest : RandomEvent
{
    public Random_StaminaTest() {
        id = 6;
    }

    public override Effect doSomething(Chara chara, Action[] actions){
        Effect result = new Effect();
        int actionLv = actions[0].getLv();
        msg.Add("体力テストを受けた");
        if (chara.getPower() >= (2 * actionLv + GameDirector.currentDay) * 25)
        {
            result.power = 5 * actionLv;
            msg.Add("テスト器具の測定可能範囲を超えた");
        }
        else if (chara.getPower() >= (2 * actionLv + GameDirector.currentDay / 4 * 3) * 25)
        {
            result.power = 3 * actionLv;
            msg.Add("平均的な結果が出た");
        }
        else
        {
            result.power = -3 * actionLv;
            msg.Add("筋力不足");
            msg.Add("かなりひどい結果だった");
        }
        return result;
    }
}
