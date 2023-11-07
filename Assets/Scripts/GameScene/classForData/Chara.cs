public class Chara
{
    // プレイヤに開示する情報 下限0, 上限まだ決めてない
    int hp;             // HP
    int power;          // 筋力
    int intelligent;    // 知力
    int mental;         // メンタル

    // 開示しない情報
    int friendly;       // 好感度（初期値0, 上限、下限(マイナス)を決める）

    public Chara (){        // contructor
        hp = 100; 
        power = 0; 
        intelligent = 0; 
        mental = 0; 
        friendly = 0;
    }
}