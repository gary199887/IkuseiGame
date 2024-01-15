using System.Collections;
using UnityEngine;


    [System.Serializable]
public class Status
{
    public int hp;             // HP
    public int power;          // 筋力
    public int intelligent;    // 知力
    public int mental;         // メンタル
    public int friendly;        //好感度

    public void fullSet(Chara chara)
    {
        this.hp = chara.getHp();
        this.power = chara.getPower();
        this.intelligent = chara.getIntelligent();
        this.mental = chara.getMental();
        this.friendly = chara.getFriendly();
    }
}
