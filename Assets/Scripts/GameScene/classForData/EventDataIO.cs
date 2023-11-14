using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataIO : MonoBehaviour
{
    //イベントデータ追加するとき専用
    EventList eventsData;

    void Start()
    {
        eventsData = new EventList();
        Event ev = new Event();
        ev.id = 1;
        ev.title = "イベント名";
        ev.imagePath = "イベント画像パス";
        ev.effect = new Effect();
        //ev.ef = new List<int> { 0,0,0,0,0,0 };
        //ev.time = 0;
        //ev.hp = 0; 
        //ev.power = 0;
        //ev.intelligent = 0;
        //ev.mental = 0;
        //ev.friendly = 0;
        eventsData.events.Add(ev);
        //ev = new Event(2, "イベント2", "./Assets/Image/Event/image.png", new List<int> { 2, 3, 1, 4, 1, 1 });
        ev = new Event(2, "イベント2", "./Assets/Image/Event/image.png", new Effect(1,2,3,1,2,3)/*,  2, 3, 1, 4, 1, 1*/);
        eventsData.events.Add(ev);

        EventManager.SaveEvents(eventsData);
        eventsData = EventManager.LoadEvents();

        Debug.Log(eventsData.events[1].id);
        Debug.Log(eventsData.events[1].title);
        Debug.Log(eventsData.events[1].imagePath);
    }
}
