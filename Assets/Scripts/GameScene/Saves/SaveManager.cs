using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] DialogManager dialogManager;
    public void save()
    {
        SaveData saveData = new SaveData();
        saveData.status=new Status();
        saveData.status.fullSet(GameDirector.chara);
        saveData.actions = ActionSelector.actions.ToList();
        saveData.nowDay = GameDirector.currentDay;
        saveData.nowHour= GameDirector.currentHour;
        saveData.events = RandomEventManager.randomEvents;
        saveData.route = FixedEventManager.route;
        saveData.charaSpriteId = FixedEventManager.currentSpriteId;
        SaveIO.DataSave(saveData);
        dialogManager.showDialog(new string[] { "ÉQÅ[ÉÄÇ™ÇπÅ[Ç‘Ç≥ÇÍÇ‹ÇµÇΩ" });
    }
}
