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

        //FixedEventIO.saveFixedEvent(fixedEventList);
    }

    // Update is called once per frame
    
}
