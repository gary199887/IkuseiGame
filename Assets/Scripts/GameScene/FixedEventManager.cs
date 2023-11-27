using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FixedEventManager : MonoBehaviour
{
    public static FixedEventList fixedEventList;        // 固定イベントリスト（GameDirectorスクリプト中に設定される）
    [SerializeField] DialogManager dialogManager;       // ダイアログマネージャー（ダイアログ表示用）
    [SerializeField] ActionSelector actionSelector;     // アクションセレクター（effect代入用）
    [SerializeField] Sprite[] sprites;                  // 画像データ（データ指定用）
    [SerializeField] SpriteRenderer eventImg;           // 画像データ代入用
    public static int route;                            // ルート（初期値-1、一回目の固定イベントでルート決定(0 ~ 2)）
    void Start()
    {
        route = -1;
    }
    public static void setFixedEvent(FixedEventList loadedList)
    {
        fixedEventList = loadedList;
    }

    public void occurFixedEvent(int currentDay)
    {
        // 何週目の固定イベントを計算
        int thisTime = currentDay / 7;
        Chara chara = new Chara(GameDirector.chara);
        // 7日目から8日目に進む時に発生
        if (thisTime == 1)
        {
            // A(筋力)ルート
            if (chara.getPower() >= chara.getIntelligent() && chara.getPower() > chara.getMental())
            {
                //doFixedEvent(fixedEventList.fixedEvents.Find(a => a.id == 0));
                doFixedEvent(fixedEventList.fixedEvents[0]);
                route = 0;
            }

            // B(知力)ルート 
            else if (chara.getIntelligent() > chara.getPower() && chara.getIntelligent() >= chara.getMental())
            {
                doFixedEvent(fixedEventList.fixedEvents[1]);
                route = 1;
            }

            // C(メンタル)ルート
            else if (chara.getMental() >= chara.getPower() && chara.getMental() > chara.getIntelligent())
            {
                doFixedEvent(fixedEventList.fixedEvents[2]);
                route = 2;
            }
            else
            { // all equal (現段階ではひとまず筋力ルートに進む)
                doFixedEvent(fixedEventList.fixedEvents[0]);
                route = 0;
            }
        }
        else if (thisTime == 2)
        {
            int upLine = 200; // イベントを決める各数値のライン 
            switch (route)
            {
                case 0:     // 筋力ルート
                    if (chara.getPower() >= upLine)
                        doFixedEvent(fixedEventList.fixedEvents[3]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[4]);
                    break;
                case 1:     // 知力ルート
                    if (chara.getIntelligent() >= upLine)
                        doFixedEvent(fixedEventList.fixedEvents[5]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[6]);
                    break;
                case 2:     // メンタルルート
                    if (chara.getMental() >= upLine)
                        doFixedEvent(fixedEventList.fixedEvents[7]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[8]);
                    break;
            }
        }
        else
        { // 三週目の固定イベント未実装
            int friendlyUpLine = 50;
            if (chara.getFriendly() >= friendlyUpLine)
                doFixedEvent(fixedEventList.fixedEvents[9 + route * 2]);
            else
                doFixedEvent(fixedEventList.fixedEvents[10 + route * 2]);
        }
    }

    void doFixedEvent(FixedEvent fixedEvent)
    {
        fixedEvent.happened = true;
        dialogManager.showDialog(stringAddToLast(fixedEvent.msg, "4時間休憩した..."));
        actionSelector.effect = fixedEvent.effect.plusEffect(new Effect(4, 20));    // イベントの影響に日付経過の影響を追加
        showEventImg(sprites[fixedEvent.id]);
    }

    public void showEventImg(Sprite img)
    {
        eventImg.sprite = img;
        eventImg.gameObject.SetActive(true);
    }

    public void hideEventImg()
    {
        eventImg.gameObject.SetActive(false);
    }

    public string[] stringAddToLast(string[] originalString, string addString)
    {
        List<string> result = new List<string>(originalString.ToList<string>());
        result.Add(addString);
        return result.ToArray();
    }
}
