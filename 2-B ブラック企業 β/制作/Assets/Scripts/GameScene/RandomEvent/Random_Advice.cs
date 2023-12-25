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
        advice.Add("�����Ƌؗ͂�L�΂��Ă݂���ǂ�����");
        advice.Add("�����ƒm�͂�L�΂��Ă݂���ǂ�����");
        advice.Add("�����ƃ����^����L�΂��Ă݂���ǂ�����");
        advice.Add("�X�e�[�^�X���ψ�ɂ��Ă݂�̂�������������Ȃ�");
        advice.Add("�����ƂȂ����Ă݂���ǂ�����");
    }
    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        msg = new List<string>() { GameDirector.currentDay + "�����o�߂���" };
        int adviceNum = Random.Range(0, advice.Count);
        msg.Add(advice[adviceNum]);
        return new Effect();
    }
}
