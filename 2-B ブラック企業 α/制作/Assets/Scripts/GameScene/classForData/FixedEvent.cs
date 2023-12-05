using System.Collections.Generic;

[System.Serializable]
public class FixedEvent : Event
{
    public bool happened;
    public FixedEvent(bool happened = false, FixedEventTrigger trigger = null) : base()
    {
        this.happened = happened;
    }
}

public class FixedEventList {
    public List<FixedEvent> fixedEvents;

    public FixedEventList(List<FixedEvent> fixedEvents = null) {
        this.fixedEvents = new List<FixedEvent>();
    
    }
}
