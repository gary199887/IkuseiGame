
public class Random_Contest : RandomEvent
{
    public Random_Contest(){
        id = 4;
    }
    override public Effect doSomething(Chara chara, Action[] actions)
    {
        Effect result = new Effect();
        msg.Add("コンテストに出場した！");
        int totalStatus = chara.getPower() + chara.getIntelligent() + chara.getMental();
        if (totalStatus >= GameDirector.currentDay * 55)
        {
            result.power = 6 * actions[0].getLv();
            result.intelligent = 6 * actions[1].getLv();
            result.mental = 6 * actions[2].getLv();
            msg.Add("最優秀賞を取った");
        }
        else if (totalStatus >= GameDirector.currentDay * 45)
        {
            result.power = 3 * actions[0].getLv();
            result.intelligent = 3 * actions[1].getLv();
            result.mental = 3 * actions[2].getLv();
            msg.Add("一応入賞したそうだ");
        }
        else {
            result.power = -3 * actions[0].getLv();
            result.intelligent = -3 * actions[1].getLv();
            result.mental = -3 * actions[2].getLv();
            msg.Add("残念ながら未入賞だった");
        }
        return result;
    }
}
