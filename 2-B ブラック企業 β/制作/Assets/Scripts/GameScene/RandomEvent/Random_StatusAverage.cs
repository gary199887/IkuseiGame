using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_StatusAverage : RandomEvent
{
    // �X�e�[�^�X���ω��C�x���g
    public Random_StatusAverage()
    {
        id = 0;
    }

    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        Effect result = new Effect();
        msg = new List<string>() { "�������Ȏ������s����", "�X�e�[�^�X�����ω����ꂽ" };
        // �ؗ́A�m�́A�����^���̕��ρi�����͐؂�̂āj
        int statusAverage = (chara.getPower() + chara.getIntelligent() + chara.getMental()) / 3;
        // �L������ڕW�̋ψ�X�e�[�^�X�ɂȂ�悤�ȉe��
        result = Effect.statusToTargetChara(chara, new Chara(0, statusAverage, statusAverage, statusAverage, 0));
        
        return result;
    }
}
