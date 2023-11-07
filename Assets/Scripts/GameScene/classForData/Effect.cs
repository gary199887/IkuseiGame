public class Effect
{
    // プレイヤに開示する情報
    public int hp;             // HP
    public int power;          // 筋力
    public int intelligent;    // 知力
    public int mental;         // メンタル

    // 開示しない情報
    public int friendly;       // 好感度

    public Effect(int hp = 0, int power = 0, int intelligent = 0, int mental = 0, int friendly = 0) {
        this.hp = hp;
        this.power = power;
        this.intelligent = intelligent;
        this.mental = mental;
        this.friendly = friendly;
    }

    public string toPlusString() {
        int hasPlusTimes = 0;
        int hasMinusTimes = 0;
        string returnString = "";
        string[] parameterName = {"HP", "筋力", "知力", "メンタル", "好感度"};
        int[] parameter = {hp, power, intelligent, mental, friendly};

        for (int i = 0; i < parameterName.Length; ++i) {
            if (parameter[i] > 0)
            {
                if (hasPlusTimes != 0)
                {
                    returnString += "と";
                }
                returnString += parameterName[i];
                hasPlusTimes++;
            }
            else {
                hasMinusTimes++;
            }
        }

        if (hasPlusTimes != 0)
            returnString += "が上がった";
        else
            returnString += "何も上がらなかった";
        return returnString;
    }
}
   
