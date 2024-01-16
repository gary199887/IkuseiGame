using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    //�X�e�[�^�X
    public Status status;
    //�s����
    public List<Action> actions;
    //�����Ǝ���
    public int nowDay;
    public int nowHour;

    //�����_���C�x���g
    public List<RandomEvent> events;

    //�L�����̃��[�g
    public int route;

    public int charaSpriteId;

    
}

