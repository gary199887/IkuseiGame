using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    SaveData saveData;

    void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void load()
    {
        if (SceneManager.GetActiveScene().name!="GameScene") return;
        saveData=new SaveData();
        saveData= SaveIO.DataLoad();
        if (saveData != null)
        {
            //キャラ
            GameDirector.chara.load(saveData.status);
            //アクション
            ActionSelector.actions = saveData.actions.ToArray();
            //日数と時間
            GameDirector.currentDay = saveData.nowDay;
            GameDirector.currentHour = saveData.nowHour;

            //育成ルート
            FixedEventManager.route = saveData.route;
            
             //キャラクターの画像
                //FixedEventManagerにあるキャラ画像を差し替えておく
            //ランダムイベントの発生済み削除
                //RandomEventManagerのランダムイベントのリストから、セーブ先のリストを参照して無くなっているものを消す　0~7のうちから
            
        }
    }
    
}
