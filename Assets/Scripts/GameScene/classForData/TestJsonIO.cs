using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestJsonIO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FixedEventList fixedEventList = new FixedEventList();
        FixedEvent fixedEvent = new FixedEvent();
        fixedEvent.effect = new Effect(0, -20, 10, 10, 0, 0);
        fixedEventList.fixedEvents.Add(fixedEvent);
        fixedEventList.fixedEvents.Add(new FixedEvent());

        EndingList endingList = new EndingList();
        endingList.endings.Add(new Ending(0, "�X�|�[�c�}���A�T�K�I�N", new string[] {"�X�|�[�c�}���ȃA�T�K�I�N", "�u�₩�Ȑl�C��" , "�ؗ́A�D���x�Ƃ��ɍ����Ɛ�������" }));
        endingList.endings.Add(new Ending(1, "�M�����O�A�T�K�I�N", new string[] { "���Љ�ȃA�T�K�I�N", "�A�����Љ�̎��", "�ؗ͂������A�D���x���Ⴂ�Ɛ�������"}));

        //EndingIO.saveEnding(endingList);
    }

    // Update is called once per frame
    
}
