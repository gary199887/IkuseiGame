using System;
using System.Collections.Generic;

[Serializable]
public class Event
{
    public int id;
    public string title;
    public string imagePath;
    //public List<int> effect;

    public int time;
    public int hp;             // HP
    public int power;          // 筋力
    public int intelligent;    // 知力
    public int mental;         // メンタル
    public int friendly;       // 好感度

    public Event()
    {
        this.id = 0;
        this.title = "";
        this.imagePath = "";

        this.time = 0;
        this.hp = 0;
        this.power = 0;
        this.intelligent = 0;
        this.mental = 0;
        this.friendly = 0;
    }
    public Event(int id, string title, string imagePath, int time, int hp, int power, int intelligent, int mental, int friendly)
    {
        this.id = id;
        this.title = title;
        this.imagePath = imagePath;

        this.time = time;
        this.hp = hp;
        this.power = power;
        this.intelligent = intelligent;
        this.mental = mental;
        this.friendly = friendly;
    }
}

[Serializable]
public class EventList
{
    public List<Event> events;
    public EventList()
    {
        this.events = new List<Event>();
    }
}