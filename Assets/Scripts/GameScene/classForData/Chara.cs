using UnityEditor;

public class Chara
{
    // プレイヤに開示する情報 下限0, 上限まだ決めてない
    int hp;             // HP
    int power;          // 筋力
    int intelligent;    // 知力
    int mental;         // メンタル

    // 開示しない情報
    public int friendly;       // 好感度（初期値0, 上限、下限(マイナス)を決める）

    public Chara (){        // contructor キャラクタの初期値を決める
        hp = 100; 
        power = 0; 
        intelligent = 0; 
        mental = 80; 
        friendly = 0;
    }

    public void addEffect(Effect effect) {      // 影響したステータスの加算
        hp += effect.hp;
        power += effect.power;
        intelligent += effect.intelligent;
        mental += effect.mental;
        friendly += effect.friendly;
    }

    public string getShowingStatus() {          // ステータス変更用文字列
        string showingStatus = $"HP:\n{hp}\n\n筋力\n{power}\n\n知力\n{intelligent}\n\nメンタル\n{mental}\n";
        return showingStatus;
    }
}