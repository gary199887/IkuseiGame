using UnityEngine;

public class SetAllButton : MonoBehaviour, MyButton
{
    [SerializeField] DictionaryManager dictionaryManager;
    [SerializeField] GameObject textObject;
    void Start()
    {
        // エンディングが一つ以上クリアされていればボタン出現
        bool hasCleared = false;
        foreach (var ending in dictionaryManager.endingList.endings)
        {
            if (ending.cleared)
            {
                hasCleared = true;
                break;
            }

        }
        gameObject.SetActive(hasCleared);
        textObject.SetActive(hasCleared);
        
    }
    public void onClicked() {
        string setClearedString = gameObject.name.Split('_')[1];
        bool setCleared = false;
        if(setClearedString.Equals("True"))
            setCleared = true;
        dictionaryManager.endingList.setAll(setCleared);
        EndingIO.saveEnding(dictionaryManager.endingList);
        dictionaryManager.Start();
    }

    public void onPointing()
    {


    }
}
