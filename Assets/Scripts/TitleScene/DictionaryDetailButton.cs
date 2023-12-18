using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryDetailButton : MonoBehaviour, MyButton
{
    [SerializeField] TitleDirector titleDirector;
    public void onClicked() {
        int id = Int32.Parse(gameObject.name.Split("_")[1]);
        titleDirector.showDictionaryDetail(id);
    }
}
