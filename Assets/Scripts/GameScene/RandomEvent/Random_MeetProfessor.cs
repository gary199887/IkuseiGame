using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_MeetProfessor : RandomEvent
{
    // �����Əo��C�x���g
    public Random_MeetProfessor()
    {
        id = 1;
    }
    override public Effect doSomething(Chara chara = null, Action[] actions = null)
    {
        Effect result = new Effect();
        msg = new List<string>() { "�����Əo�����" };
        if (chara.getFriendly() >= 25)
        {
            result.friendly = 10;
            msg.Add("�L���Ȋ֌W��z���Ă���悤���ˁB");
            msg.Add("���ꂩ����琬�ɗ�ނ悤�ɁB");
        }
        else
        {
            result.friendly = -10;
            msg.Add("���̐A���͌N�̂��Ƃ����܂�D���Ă��Ȃ��悤���B");
            msg.Add("�����ƂȂ����Ă݂Ă͂ǂ������B");
        }
        return result;
    }
}
