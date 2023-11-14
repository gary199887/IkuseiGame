using System;
using System.Collections.Generic;

[Serializable]
public class Event
{
    public int id;
    public string title;
    public string imagePath;
    public Effect effect;


    public Event()
    {
        this.id = 0;
        this.title = "";
        this.imagePath = "";
        this.effect = new Effect();
    }
    public Event(int id, string title, string imagePath, Effect effect)
    {
        this.id = id;
        this.title = title;
        this.imagePath = imagePath;
        this.effect = effect;
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