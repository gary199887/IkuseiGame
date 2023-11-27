[System.Serializable]
public class Event
{
    public int id;
    public string name;
    public string[] msg;
    public Effect effect;

    public Event(int id = 0, string name = "", string[] msg = null, Effect effect = null)
    {
        this.id = id;
        this.name = name;
        this.msg = msg;
        this.effect = effect;
    }
}