using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryButton : MonoBehaviour, MyButton
{
    [SerializeField] TitleDirector titleDirector;
    public void onClicked() {
        titleDirector.showDictionary();
    }

    public void onPointing()
    {
        transform.localScale.Set(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f, transform.localScale.z);
    }
}
