using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleDirector : CommonFunctions
{
    float timeCount;
    bool skipped;
    bool typingDone;
    public static bool buttonClicked;
    string title = "The Seed: Origin";
    [SerializeField] Text titleObj;
    [SerializeField] GameObject buttons;
    [SerializeField] TitleAudioManager titleAudioManager;
    [SerializeField] GameObject titleChara;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        typingDone = false;
        titleObj.text = keepTalking(title);
        buttons.SetActive(false);
        buttonClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        endGameWithEsc();
        timeCount += Time.deltaTime;
        titleObj.text = keepTalking(title) + blinkingHint();
        if (typingDone) {
            if (!buttons.activeSelf) buttons.SetActive(true);
            titleAudioManager.stopKeyboardSE();
            titleAudioManager.playBGM();

            // タイトルキャラフェードイン（仮）
            if (titleChara.transform.position.y < -2.57f) titleChara.transform.Translate(new Vector2(0, 1.0f * Time.deltaTime));
        }

        if (buttonClicked) {
            titleAudioManager.playConfirmSE();
            buttonClicked = false;
        }
        if (sentenceCompleted())
        {
         typingDone = true;
        }
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
    {                         // turn the last of the santence + "　▼" on/off in every 0.5 sec 
        const float blinkCd = 0.5f;
        if ((int)(timeCount / blinkCd % 2) == 0) { return "|"; }
        
        return " ";
    }
}
