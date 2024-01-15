using System;
using System.Collections.Generic;

[System.Serializable]
public class RandomEvent
{
    public int id;              // �摜�f�[�^�����ւ��p
    public List<string> msg;    // ���b�Z�[�W�\���p
    

    public RandomEvent() {
        msg = new List<string>();
    }
    // Chara, Action[]: �������f�p(�X�e�[�^�X�A�s��L��)
    public virtual Effect doSomething(Chara chara, Action[] actions) { return null; }
}
