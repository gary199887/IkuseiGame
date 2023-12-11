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
        msg.Add("����ɏo������");
        if (chara.getMental() >= (2 * actionLv + GameDirector.currentDay) * 25)
        {
            result.mental = 5 * actionLv;
            msg.Add("���߂ĂȂ̂ɂ܂�Ńx�e�����̂悤�ȗ��������悤��");
        }
        else if (chara.getMental() >= (2 * actionLv + GameDirector.currentDay / 4 * 3) * 25)
        {
            result.mental = 3 * actionLv;
            msg.Add("��G�̖�����点��");
            msg.Add("�S�R�Z���t�Ȃ��̂ł̂ł�����Ƒދ�������");
        }
        else
        {
            result.mental = -3 * actionLv;
            msg.Add("���肷����SNS�ŉ��サ��");
        }
        return result;
    }
}
