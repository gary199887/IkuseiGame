using UnityEngine;

public class SetAllButton : MonoBehaviour, MyButton
{
    [SerializeField] DictionaryManager dictionaryManager;
    [SerializeField] GameObject textObject;
    void Start()
    {   
        // �G���f�B���O����ȏ�N���A����Ă���΃{�^���o��
        //bool hasCleared = false;
        //foreach (var ending in dictionaryManager.endingList.endings)
        //    if (ending.cleared) {
        //        hasCleared = true;
        //        break;
        //    }
        //if (!hasCleared) { gameObject.SetActive(false); textObject.SetActive(false); }
        //else { gameObject.SetActive(true); textObject.SetActive(true); }
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
}