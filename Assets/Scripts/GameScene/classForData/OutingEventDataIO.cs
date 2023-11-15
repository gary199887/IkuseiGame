using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutingEventDataIO : MonoBehaviour
{
    //外出イベントデータ追加するとき専用
    OutingEventList eventsData;

    void Start()
    {
        eventsData = new OutingEventList();
        OutingEvent ev = new OutingEvent();

        ev.id = 1;
        ev.title = "イベント名";
        ev.msg = new string[] { "テスト", "test" };
        ev.imagePath = "イベント画像パス";
        ev.effect = new Effect();
        eventsData.events.Add(ev);

        ev = new OutingEvent(2, "イベント2", new string[] { "テスト", "test" }, "./Assets/Image/Event/image.png", new Effect(1, 2, 3, 1, 2, 3));
        eventsData.events.Add(ev);

        OutingEventManager.SaveEvents(eventsData);
        eventsData = OutingEventManager.LoadEvents();

        Debug.Log(eventsData.events[1].id);
        Debug.Log(eventsData.events[1].title);
        Debug.Log(eventsData.events[1].imagePath);
    }
}
