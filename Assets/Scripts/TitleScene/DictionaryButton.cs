using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryButton : MonoBehaviour, MyButton
{
    [SerializeField] TitleDirector titleDirector;
    public void onClicked() {
        titleDirector.showDictionary();
    }
}
