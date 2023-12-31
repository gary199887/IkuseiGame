using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OutingEventManager : MonoBehaviour
{
    [SerializeField] GameObject outingEvent;
    [SerializeField] GameDirector gameDirector;
    [SerializeField] DialogManager dialogManager;
    [SerializeField] ActionSelector actionSelector;
    [SerializeField] Image eventImage;
    [System.Serializable]
    class EventSprites
    {
        public List<Sprite> sprite;
    }
    [SerializeField] List<EventSprites> eventSprites;

    int happeningEvent;

    static OutingEventList outingEventList;

    private void Start()
    {
        outingEvent.SetActive(false);
    }

    public static void SetOutingEvent(OutingEventList loadedList)
    {
        outingEventList = loadedList;
    }
    private void Update()
    {
        if (outingEvent.activeSelf) {
            CommonFunctions.ImagesAnimation(eventImage, eventSprites[happeningEvent].sprite);
        }
    }

    public void ShowOutingEvent(int eventNum)
    {
        happeningEvent = eventNum;
        outingEvent.SetActive(true);
        eventImage.sprite = eventSprites[eventNum].sprite[0];
    }

    public void CloseOutingEvent()
    {
        outingEvent.SetActive(false);
    }

    public void DoOutingEvent(Action[] actions)
    {
        int eventNum = Random.Range(0, outingEventList.events.Count);    // イベント数に応じてランダム

        //actionSelector.effect = outingEventList.events[eventNum].effect;  // 行動レベル乗算なし
        actionSelector.effect = EffectMultipleActionLv(actions, outingEventList.events[eventNum].effect);   // 行動レベル乗算あり
        Effect effect = actionSelector.effect;
        gameDirector.changeParameter(effect);

        string[] eventMsg = outingEventList.events[eventNum].msg;
        string[] effectMsg = { effect.getPlusMsg(), effect.getMinusMsg() };
        string[] msg = eventMsg.Concat(effectMsg).ToArray();  // 配列の結合
        dialogManager.showDialog(msg);

        ShowOutingEvent(eventNum);
    }

    // 影響の各数値に行動レベルを乗算
    Effect EffectMultipleActionLv(Action[] actions, Effect effect)
    {
        Effect result = new Effect();
        result.hp = effect.hp;
        result.time = effect.time;
        result.friendly = effect.friendly;

        result.power = effect.power * actions[0].getLv();
        result.intelligent = effect.intelligent * actions[1].getLv();
        result.mental = effect.mental * actions[2].getLv();
        
        return result;
    }
}
