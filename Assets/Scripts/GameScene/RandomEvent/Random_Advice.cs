using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Advice : RandomEvent
{
    // �A�h�o�C�X�C�x���g
    private List<string> advice = new List<string>();
    
    public Random_Advice() 
    {
        id = 2;
        advice.Add("�����Ƌؗ͂�L�΂��Ă݂悤!");
        advice.Add("�����ƒm�͂�L�΂��Ă݂悤!");
        advice.Add("�����ƃ����^����L�΂��Ă݂悤!");
        advice.Add("�X�e�[�^�X���ψ�ɐL�΂��Ă݂�̂�������������Ȃ�");
        advice.Add("�����ƂȂ����Ă݂悤!");
    }
    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        msg = new List<string>() { GameDirector.currentDay + "�����o�߂���" };
        int adviceNum = Random.Range(0, advice.Count);
        msg.Add(advice[adviceNum]);
        return new Effect();
    }
}
