[System.Serializable]
public class Effect
{
    public int time;
    // プレイヤに開示する情報
    public int hp;             // HP
    public int power;          // 筋力
    public int intelligent;    // 知力
    public int mental;         // メンタル

    // 開示しない情報
    public int friendly;       // 好感度

    string[] parameterName = { "HP", "筋力", "知力", "メンタル", "好感度" };       // パラメータ名
    public Effect(int time = 0,int hp = 0, int power = 0, int intelligent = 0, int mental = 0, int friendly = 0) {
        this.time = time;
        this.hp = hp;
        this.power = power;
        this.intelligent = intelligent;
        this.mental = mental;
        this.friendly = friendly;
    }

    public Effect(Effect copyFrom) {
        this.time = copyFrom.time;
        this.hp = copyFrom.hp;
        this.power = copyFrom.power;
        this.intelligent = copyFrom.intelligent;
        this.mental = copyFrom.mental;
        this.friendly = copyFrom.friendly;
    }
    string getChangedMsg(int mode){  // 変動したメッセージを取得(private)    modeが0の場合は上がった数値 、 0以外の場合は下がった数値の判定
        int hasChangedTimes = 0;        // 変動した回数(”と”を入れるため)
        string returnString = "";       // 返す文字列(結果)
        int[] parameter = { hp, power, intelligent, mental, friendly };     // 影響する各パラメータ

        for (int i = 0; i < parameterName.Length; ++i)
        {
            if (mode == 0 ? parameter[i] > 0 : parameter[i] < 0)
            {
                if (hasChangedTimes != 0)
                    // 前に変化した数値があると“と”を入れる
                    returnString += "と";
                // 変化したパラメータ名を入れる
                returnString += parameterName[i];
                // 変化した回数を加算
                hasChangedTimes++;
            }
        }

        if (hasChangedTimes != 0)
            returnString += mode == 0 ? "が上がった" :"が下がった";
        else
            returnString += mode == 0 ? "何も上がらなかった" : "何も下がらなかった";
        return returnString;
    }

    public string getPlusMsg() {     // 上昇したパラメータ変更メッセージ
        return getChangedMsg(0);
    }

    public string getMinusMsg()
    {     // 減少したパラメータ変更メッセージ
        return getChangedMsg(1);
    }

    // 両Effectクラスを加算するためのメソッド　
    public Effect plusEffect(Effect addEffect) {
        Effect result = new Effect(this);
        result.time += addEffect.time;
        result.hp += addEffect.hp;
        result.power += addEffect.power;
        result.intelligent += addEffect.intelligent;
        result.mental += addEffect.mental;
        result.friendly += addEffect.friendly;

        return result;
    }
}
   
