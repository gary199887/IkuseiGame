using System;
using System.Collections.Generic;

[Serializable]
public class OutingEvent
{
    public int id;
    public string title;
    public string[] msg;
    public string imagePath;
    public Effect effect;


    public OutingEvent()
    {
        this.id = 0;
        this.title = "";
        this.msg = new string[] { "" };
        this.imagePath = "";
        this.effect = new Effect();
    }
    public OutingEvent(int id, string title, string[] msg, string imagePath, Effect effect)
    {
        this.id = id;
        this.title = title;
        this.msg = msg;
        this.imagePath = imagePath;
        this.effect = effect;
    }
}

[Serializable]
public class OutingEventList
{
    public List<OutingEvent> events;
    public OutingEventList()
    {
        this.events = new List<OutingEvent>();
    }
}