public class Ending
{
    public int id;
    public string name;
    public string[] description;

    public Ending(int id = 0, string name = "謎の植物", string[] description = null) {
        this.id = id;
        this.name = name;
        this.description = description;
        if(this.description == null)
            this.description = new string[]{"訳の分からない凶暴な植物である", "雑食", "生態系ピラミッドの頂点を君臨する", "やがて人類をも食べ尽くしたのであった"};
    }
}
