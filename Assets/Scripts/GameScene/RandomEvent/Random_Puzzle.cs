

public class Random_Puzzle : RandomEvent
{
    public Random_Puzzle() {
        id = 5;
    }

    public override Effect doSomething(Chara chara, Action[] actions)
    {
        Effect result = new Effect();
        int actionLv = actions[1].getLv();
        msg.Add("�p�Y���������Ă݂�");
        if (chara.getIntelligent() >= (2 * actionLv + GameDirector.currentDay) * 25)
        {
            result.intelligent = 5 * actionLv;
            msg.Add("���A�A�������I�قƂ�ǎ��Ԃ�����Ȃ������I");
        }
        else if (chara.getIntelligent() >= (2 * actionLv + GameDirector.currentDay / 4 * 3) * 25)
        {
            result.intelligent = 3 * actionLv;
            msg.Add("����Ȃ�Ɏ��Ԃ�������");
        }
        else {
            result.intelligent = -3 * actionLv;
            msg.Add("�S�R�����Ȃ�����");
        }
        return result;
    }
}
