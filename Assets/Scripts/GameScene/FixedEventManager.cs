using UnityEngine;

public class FixedEventManager : MonoBehaviour
{
    public static FixedEventList fixedEventList;        // 固定イベントリスト（GameDirectorスクリプト中に設定される）
    [SerializeField] DialogManager dialogManager;       // ダイアログマネージャー（ダイアログ表示用）
    [SerializeField] ActionSelector actionSelector;     // アクションセレクター（effect代入用）
    [SerializeField] Sprite[] sprites;                  // 画像データ（データ指定用）
    [SerializeField] SpriteRenderer eventImg;           // 画像データ代入用
    public static int route;                            // ルート（初期値-1、一回目の固定イベントでルート決定(0 ~ 2)）
    int thisTime;
    public static int currentSpriteId = -1;
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
        thisTime = currentDay / 7;
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
                doFixedEvent(fixedEventList.fixedEvents[15]);
                route = 3;
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
                case 3:     // 均等ルート
                    if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())    // 均等
                        doFixedEvent(fixedEventList.fixedEvents[15]);
                    else　　　// 数値がそろってない
                    {
                        doFixedEvent(fixedEventList.fixedEvents[16]);
                        route = 4;
                    }
                    break;
            }
        }
        else
        { // 三週目の固定イベント
            int friendlyUpLine = 50;
            if (route < 3)
                if (chara.getFriendly() >= friendlyUpLine)
                    doFixedEvent(fixedEventList.fixedEvents[9 + route * 2]);
                else
                    doFixedEvent(fixedEventList.fixedEvents[10 + route * 2]);
            else
            {
                if (route == 3)
                {
                    if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())
                        doFixedEvent(fixedEventList.fixedEvents[17]);
                }
                else
                {
                    if (chara.getPower() == chara.getIntelligent() && chara.getPower() == chara.getMental())
                        doFixedEvent(fixedEventList.fixedEvents[15]);
                    else
                        doFixedEvent(fixedEventList.fixedEvents[16]);
                }
            }

        }
    }

    void doFixedEvent(FixedEvent fixedEvent)
    {
        fixedEvent.happened = true;
        dialogManager.showDialog(CommonFunctions.stringAddToLast(fixedEvent.msg, "4時間休憩した..."));    // 固定イベントメッセージ表示(最後に4時間休憩したと文言追加)
        if (fixedEvent.id == 16)
        {
            Chara chara = new Chara(GameDirector.chara);
            int statusAverage = (chara.getPower() + chara.getIntelligent() + chara.getMental()) / 3;
            fixedEvent.effect = Effect.statusToTargetChara(chara, new Chara(0, statusAverage, statusAverage, statusAverage, 0));
        }
        actionSelector.effect = fixedEvent.effect.plusEffect(new Effect(4, 20));    // イベントの影響に日付経過の影響を追加（4時間経過、HP＋20）
        if (fixedEvent.id < 15)
        {
            showEventImg(sprites[fixedEvent.id]);
            currentSpriteId = fixedEvent.id;
        }
        else
        {
            switch (thisTime)
            {
                case 1:
                    showEventImg(sprites[2]);
                    currentSpriteId = 2;
                    break;
                case 2:
                    showEventImg(sprites[8]);
                    currentSpriteId = 8;
                    break;
                case 3:
                    showEventImg(sprites[14]);
                    currentSpriteId = 14;
                    break;
            }
        }

    }
    public void loadEventImg(int day,int route) 
    {
        //芽になる条件
        if (day >= 7&&day<=14)
        {
            switch (route)
            {
                case 0:
                    showEventImg(sprites[0]);
                    break;
                case 1:
                    showEventImg(sprites[1]);
                    break;
                case 2:
                    showEventImg(sprites[2]);
                    break;
                case 3:
                    showEventImg(sprites[2]);
                    break;
            }
        }
        //つぼみになる条件
        else if(day >= 15 && day <= 21)
        {
            switch (route)
            {
                case 0:
                    showEventImg(sprites[3]);
                    break;
                case 1:
                    showEventImg(sprites[5]);
                    break;
                case 2:
                    showEventImg(sprites[7]);
                    break;
                case 3:
                    showEventImg(sprites[7]);
                    break;
            }
       }
        
        
        //花になる条件
        else if(day >= 22)
        {
            switch (route)
            {

                case 0:
                    showEventImg(sprites[9]);
                    break;
                case 1:
                    showEventImg(sprites[11]);
                    break;
                case 2:
                    showEventImg(sprites[13]);
                    break;
                case 3:
                    showEventImg(sprites[13]);
                    break;
            }
        }


    }
    public void showEventImg(Sprite img)
    {
        eventImg.sprite = img;
        eventImg.gameObject.SetActive(true);
    }

    public void changeSprite(int id) {
        currentSpriteId = id;
        eventImg.sprite = sprites[id];
        eventImg.gameObject.SetActive(true);
    }

    public void hideEventImg()
    {
        eventImg.gameObject.SetActive(false);
    }

}
