using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    //ステータス
    public Status status;
    //行動回数
    public List<Action> actions;
    //日数と時間
    public int nowDay;
    public int nowHour;

    //ランダムイベント
    public List<RandomEvent> events;

    //キャラのルート
    public int route;

    public int charaSpriteId;

    
}

