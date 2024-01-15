using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
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
        SaveIO.DataSave(saveData);
    }
}
