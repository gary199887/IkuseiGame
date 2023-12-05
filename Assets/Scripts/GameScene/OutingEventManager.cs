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
    [SerializeField] Sprite[] eventSprites;

    static OutingEventList outingEventList;

    private void Start()
    {
        outingEvent.SetActive(false);
    }

    public static void SetOutingEvent(OutingEventList loadedList)
    {
        outingEventList = loadedList;
    }

    public void CloseOutingEvent()
    {
        outingEvent.SetActive(false);
    }

    public void DoOutingEvent(Action[] actions)
    {
        int eventNum = Random.Range(0, outingEventList.events.Count);    // �C�x���g���ɉ����ă����_��

        //actionSelector.effect = outingEventList.events[eventNum].effect;  // �s�����x����Z�Ȃ�
        actionSelector.effect = EffectMultipleActionLv(actions, outingEventList.events[eventNum].effect);   // �s�����x����Z����
        Effect effect = actionSelector.effect;
        gameDirector.changeParameter(effect);

        string[] eventMsg = outingEventList.events[eventNum].msg;
        string[] effectMsg = { effect.getPlusMsg(), effect.getMinusMsg() };
        string[] msg = eventMsg.Concat(effectMsg).ToArray();  // �z��̌���
        dialogManager.showDialog(msg);

        eventImage.sprite = eventSprites[eventNum];
        outingEvent.SetActive(true);
    }

    // �e���̊e���l�ɍs�����x������Z
    Effect EffectMultipleActionLv(Action[] actions, Effect effect)
    {
        Effect result = new Effect();
        result.hp = effect.hp;
        result.time = effect.time;
        result.friendly = effect.friendly;
        if (effect.power != 0)
        {
            result.power = effect.power * actions[0].getLv();
        }
        if (effect.intelligent != 0)
        {
            result.intelligent = effect.intelligent * actions[1].getLv();
        }
        if (effect.mental != 0)
        {
            result.mental = effect.mental * actions[2].getLv();
        }
        return result;
    }
}
