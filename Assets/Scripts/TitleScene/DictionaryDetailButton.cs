using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryDetailButton : MonoBehaviour, MyButton
{
    [SerializeField] TitleDirector titleDirector;
    int endingNum;
    void Start()
    {
        endingNum = Int32.Parse(gameObject.name.Split('_')[1]);
    }
    public void onClicked() {
        if (titleDirector.checkIfEndingCleared(endingNum))
            titleDirector.showDictionaryDetail(endingNum);
        else
            titleDirector.showHint(endingNum);
    }
}
