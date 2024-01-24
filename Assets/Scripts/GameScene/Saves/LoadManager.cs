using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadManager : MonoBehaviour
{
    SaveData saveData;
    [SerializeField] FixedEventManager fixedEventManager;
    [SerializeField] HintManager hintManager;
    public void load()
    {
        if (SceneManager.GetActiveScene().name!="GameScene") return;
        saveData=new SaveData();
        saveData= SaveIO.DataLoad();
        if (saveData != null)
        {
            //キャラ
            GameDirector.chara = new Chara(saveData.status);
            //アクション
            ActionSelector.actions = saveData.actions.ToArray();
            for(int i = 0; i < 3; ++i)
                hintManager.lvUpInUI(i, saveData.actions[i].lv);

            //日数と時間
            GameDirector.currentDay = saveData.nowDay;
            GameDirector.currentHour = saveData.nowHour;

            //育成ルート
            FixedEventManager.route = saveData.route;

            //キャラクターの画像
            //FixedEventManagerにあるキャラ画像を差し替えておく
            if(saveData.charaSpriteId != -1)
                fixedEventManager.changeSprite(saveData.charaSpriteId);

            //ランダムイベントの発生済み削除
            saveData.events.Sort((a, b) => {
                return a.id.CompareTo(b.id);
            });

           
            RandomEventManager.randomEvents.Sort((a, b) =>
            {
                return a.id.CompareTo(b.id);
            });

            //RandomEventManagerのランダムイベントのリストから、セーブ先のリストを参照して無くなっているものを消す　0~7のうちから
            for (int i = 0; i < saveData.events.Count;) {
                if (saveData.events[i].id != RandomEventManager.randomEvents[i].id)
                {
                    RandomEventManager.randomEvents.RemoveAt(i);
                }
                else
                    ++i;
            }
               
            
        }
    }
    
}
