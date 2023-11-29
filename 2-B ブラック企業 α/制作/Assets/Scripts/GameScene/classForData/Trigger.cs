[System.Serializable]
public class Trigger
{
    public enum Parameter {
        Hp, Power, Intelligent, Mental, Friendly
    }

    public Parameter parameter;
    public int needed;

    public Trigger(Parameter parameter = 0, int needed = 0) {
        this.parameter = parameter;
        this.needed = needed;
    }
}

[System.Serializable]
public class FixedEventTrigger : Trigger {
    public int happenDay;

    public FixedEventTrigger(int happenDay = 0)
    {
        this.happenDay = happenDay;
    }
}