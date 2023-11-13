
public class Action
{
    public string name;
    public int times;
    public int lv;
    public int[] lvUp = { 3, 10, 20, 33};

    public Action(string name) {
        this.name = name;
        times = 0;
        lv = 1;
    }

    public string doAction() {
        times++;
        for (int i = 0; i < lvUp.Length; ++i)
            if (times == lvUp[i]) {
                lv = i + 2;
                return $"s“®ƒŒƒxƒ‹Up!\nlv{lv - 1}->lv{lv}";
            }
        return null;
    }

    public int getLv() {
        return lv;
    }
}
