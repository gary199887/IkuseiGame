using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    [SerializeField] GameDirector gameDirector;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] DialogManager dialogManager;
    List<RandomEvent> randomEvents;             // �����\�胉���_���C�x���g�o�b�t�@�[

    private void Start()
    {
        // �e�탉���_���C�x���g���o�b�t�@�[�ɒǉ�
        randomEvents = new List<RandomEvent>{ new Random_Contest() };
    }
    // �����_���C�x���g����
    public void occurRandomEvent() {
        // �o�b�t�@�[�Ƀ����_���C�x���g���c���Ă���ꍇ
        if (randomEvents.Count > 0)
        {   // �������Ă���C�x���g���o�b�t�@�[���烉���_���Ō��߂� 
            RandomEvent happeningEvent = randomEvents[Random.Range(0, randomEvents.Count)];

            // �C�x���g���������i�e���𓾂�A���b�Z�[�W�����ρj
            Effect effect = happeningEvent.doSomething(GameDirector.chara, ActionSelector.actions);
            // �C�x���g���猋�ʂɉ��������b�Z�[�W���擾
            List<string>msg = new List<string>(happeningEvent.msg);
            // �e������
            actionSelector.effect = effect;
            // �e�����p�����[�^�ɓK�p
            gameDirector.changeParameter(actionSelector.effect);
            
            // ���b�Z�[�W�ɃG�t�F�N�g�ɉ������㏸�A�~�����ڂ�ǉ�
            msg.Add(effect.getPlusMsg());
            msg.Add(effect.getMinusMsg());
            // ���b�Z�[�W��\��
            dialogManager.showDialog(msg.ToArray());
            
            // ���������C�x���g���o�b�t�@�[����폜
            randomEvents.Remove(happeningEvent);
        }  
    }
}
