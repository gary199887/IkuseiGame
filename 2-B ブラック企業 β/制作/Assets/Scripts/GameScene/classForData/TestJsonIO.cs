using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestJsonIO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FixedEventList fixedEventList = new FixedEventList();
        FixedEvent fixedEvent = new FixedEvent();
        fixedEvent.effect = new Effect(0, -20, 10, 10, 0, 0);
        fixedEventList.fixedEvents.Add(fixedEvent);
        fixedEventList.fixedEvents.Add(new FixedEvent());

        EndingList endingList = new EndingList();
        endingList.endings.Add(new Ending(0, "スポーツマンアサガオ君", new string[] {"スポーツマンなアサガオ君", "爽やかな人気者" , "筋力、好感度ともに高いと成長する" }));
        endingList.endings.Add(new Ending(1, "ギャングアサガオ君", new string[] { "裏社会なアサガオ君", "植物裏社会の首領", "筋力が高く、好感度が低いと成長する"}));

        //EndingIO.saveEnding(endingList);
    }

    // Update is called once per frame
    
}
