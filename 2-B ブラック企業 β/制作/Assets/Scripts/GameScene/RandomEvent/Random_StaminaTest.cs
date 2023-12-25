
public class Random_StaminaTest : RandomEvent
{
    public Random_StaminaTest() {
        id = 6;
    }

    public override Effect doSomething(Chara chara, Action[] actions){
        Effect result = new Effect();
        int actionLv = actions[0].getLv();
        msg.Add("�̗̓e�X�g���󂯂�");
        if (chara.getPower() >= (2 * actionLv + GameDirector.currentDay) * 25)
        {
            result.power = 5 * actionLv;
            msg.Add("�e�X�g���̑���\�͈͂𒴂���");
        }
        else if (chara.getPower() >= (2 * actionLv + GameDirector.currentDay / 4 * 3) * 25)
        {
            result.power = 3 * actionLv;
            msg.Add("���ϓI�Ȍ��ʂ��o��");
        }
        else
        {
            result.power = -3 * actionLv;
            msg.Add("�͕ؗs��");
            msg.Add("���Ȃ�Ђǂ����ʂ�����");
        }
        return result;
    }
}
