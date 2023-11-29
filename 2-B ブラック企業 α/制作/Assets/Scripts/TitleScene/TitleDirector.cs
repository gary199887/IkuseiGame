using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
    float timeCount;
    bool skipped;
    string title = "The Seed: Origin";
    [SerializeField] Text titleObj;
    [SerializeField] GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        titleObj.text = keepTalking(title);
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CommonFunctions.endGameWithEsc();
        timeCount += Time.deltaTime;
        titleObj.text = keepTalking(title) + blinkingHint();
        if(sentenceCompleted())
            buttons.SetActive(true);
    }

    string keepTalking(string fullSentence)
    {       // turn full sentence into increasing words depends on timeCount and cd of one word(currently be set with 0.1 sec)
        const float oneWordCd = 0.1f;
        if (!skipped) return fullSentence.Substring(0, (int)Mathf.Clamp((timeCount / oneWordCd), 0, fullSentence.Length));  // set the max number for substring to prevent indexOutOfBound
        else return fullSentence;
    }

    bool sentenceCompleted()
    {                      // check if current sentence has been completely shown
        bool result = keepTalking(title).Length == title.Length;
        if (!result)
        {
            //if (!talkSE.isPlaying) talkSE.Play();
        }
        //else talkSE.Stop();
        return result;
    }

    string blinkingHint()
    {                         // turn the last of the santence + "Б@Бе" on/off in every 0.5 sec 
        const float blinkCd = 0.5f;
        if ((int)(timeCount / blinkCd % 2) == 0) { return "|"; }
        
        return " ";
    }
}
