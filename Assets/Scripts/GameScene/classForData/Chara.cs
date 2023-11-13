using System;
using UnityEditor;

public class Chara
{
    // プレイヤに開示する情報 下限0, 上限まだ決めてない
    int hp;             // HP
    int power;          // 筋力
    int intelligent;    // 知力
    int mental;         // メンタル

    const int minHP = 0;
    const int maxHP = 100;
    const int minPower = 0;
    const int maxPower = 999;
    const int minIntelligent = 0;
    const int maxIntelligent = 999;
    const int minMental = 0;
    const int maxMental = 999;

    // 開示しない情報
    int friendly;       // 好感度（初期値0, 上限、下限(マイナス)を決める）

    const int minFriendly = -50;
    const int maxFriendly = 50;


    public Chara (){        // contructor キャラクタの初期値を決める
        hp = 100; 
        power = 100; 
        intelligent = 100; 
        mental = 100; 
        friendly = 0;
    }

    public void doEffect(Effect effect) {      // 影響したステータスの加算
        // 変更前の数値を保存
        int beforeHP = hp;
        // 数値加算、最小値と最大値の範囲内に制限
        hp = Math.Clamp(hp + effect.hp, minHP, maxHP);
        // 実際変動した数値をeffectに代入(正しい変更メッセージを取得するため)
        effect.hp = hp - beforeHP;

        // 以下同様
        
        int beforePower = power;
        power = Math.Clamp(power + effect.power, minPower, maxPower);
        effect.power = power - beforePower;

        int beforeIntelligent = intelligent;
        intelligent = Math.Clamp(intelligent + effect.intelligent, minIntelligent, maxIntelligent);
        effect.intelligent = intelligent - beforeIntelligent;
        

        int beforeMental = mental;
        mental = Math.Clamp(mental + effect.mental, minMental, maxMental);
        effect.mental = mental - beforeMental;

        int beforeFriendly = friendly;
        friendly = Math.Clamp(friendly + effect.friendly, minFriendly, maxFriendly);
        effect.friendly = friendly - beforeFriendly;
    }

    public string getShowingStatus() {          // ステータス変更用文字列
        string showingStatus = $"HP:\n{hp}\n\n筋力\n{power}\n\n知力\n{intelligent}\n\nメンタル\n{mental}\n";
        return showingStatus;
    }
}