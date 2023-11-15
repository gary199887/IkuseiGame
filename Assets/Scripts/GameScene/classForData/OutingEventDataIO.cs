using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutingEventDataIO : MonoBehaviour
{
    //�O�o�C�x���g�f�[�^�ǉ�����Ƃ���p
    OutingEventList eventsData;

    void Start()
    {
        eventsData = new OutingEventList();
        OutingEvent ev = new OutingEvent();

        ev.id = 1;
        ev.title = "�C�x���g��";
        ev.msg = new string[] { "�e�X�g", "test" };
        ev.imagePath = "�C�x���g�摜�p�X";
        ev.effect = new Effect();
        eventsData.events.Add(ev);

        ev = new OutingEvent(2, "�C�x���g2", new string[] { "�e�X�g", "test" }, "./Assets/Image/Event/image.png", new Effect(1, 2, 3, 1, 2, 3));
        eventsData.events.Add(ev);

        OutingEventManager.SaveEvents(eventsData);
        eventsData = OutingEventManager.LoadEvents();

        Debug.Log(eventsData.events[1].id);
        Debug.Log(eventsData.events[1].title);
        Debug.Log(eventsData.events[1].imagePath);
    }
}
