using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Contest : RandomEvent
{
    public Random_Contest(){
        id = 4;
    }
    override public Effect doSomething(Chara chara, Action[] actions)
    {
        Effect result = new Effect();
        msg.Add("�R���e�X�g�ɏo�ꂵ���I");
        int totalStatus = chara.getPower() + chara.getIntelligent() + chara.getMental();
        if (totalStatus >= GameDirector.currentDay * 55)
        {
            result.power = 5 * actions[0].getLv();
            result.intelligent = 5 * actions[1].getLv();
            result.mental = 5 * actions[2].getLv();
            msg.Add("�ŗD�G�܂������");
        }
        else if (totalStatus >= GameDirector.currentDay * 45)
        {
            result.power = 3 * actions[0].getLv();
            result.intelligent = 3 * actions[1].getLv();
            result.mental = 3 * actions[2].getLv();
            msg.Add("�ꉞ���܂���������");
        }
        else {
            result.power = -3 * actions[0].getLv();
            result.intelligent = -3 * actions[1].getLv();
            result.mental = -3 * actions[2].getLv();
            msg.Add("�c�O�Ȃ��疢���܂�����");
        }
        return result;
    }
}
