using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // game object and components to control
    public GameObject dialog;
    public Text dialogText;
    //AudioSource talkSE;

    // local datas
    float timeCount;        // timer
    const float cd = 0.1f;  // gap between one action and another
    string[] talks;         // several sentences of the chosen charactor
    int currentIndex;       // current sentence id
    bool skipped;           // used to check if the single sentence has been skipped of not
    [SerializeField] GameDirector gameDirector;
    [SerializeField] ButtonFuctions buttonFuctions;


    private void Start()
    {
        timeCount = 0;
        //talkSE = GetComponent<AudioSource>();
        dialog.SetActive(false);
        currentIndex = 0;
        skipped = false;

    }

    private void Update()
    {
        if (!dialog.activeSelf) return;
        timeCount += Time.deltaTime;
        dialogText.text = keepTalking(talks[currentIndex] + blinkingHint());

        if (currentIndex < talks.Length - 1)    // when current index is not the last one
        {
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel") || Input.GetButtonDown("Fire1"))  // when z / enter / x key down and allowed do something
            {
                if (timeCount > cd)
                {
                    // move to next sentence if this one is completely shown
                    if (sentenceCompleted())
                    {
                        currentIndex++;
                        skipped = false;
                    }

                    // skip word counting and just show the full sentence
                    else
                    {
                        skipped = true;
                    }
                    timeCount = 0;
                }
            }
        }
        else            // when current sentence id is at the last one
        {
            if ((Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel") ) || Input.GetButtonDown("Fire1") && timeCount > cd)  // when z / enter / x key down and allowed do something
            {
                // close dialog system and move back to talk system if the last sentence is completely shown
                if (sentenceCompleted())
                {
                    skipped = false;
                    timeCount = 0;
                    currentIndex = 0;
                    dialog.SetActive(false);
                    buttonFuctions.showButtons();
                }

                // skip word counting and just show the full sentence
                else
                {
                    skipped = true;
                    timeCount = 0;
                }
            }
        }
    }
    public void showDialog(string[] talks) {    // to start dialog system
        this.talks = talks;                     // set the local talks into the thrown-in string array

        // clear or initialize parameters
        timeCount = 0;
        currentIndex = 0;
        skipped = false;

        // make dialog UI visible
        dialog.SetActive(true);
    }

    string keepTalking(string fullSentence) {       // turn full sentence into increasing words depends on timeCount and cd of one word(currently be set with 0.1 sec)
        const float oneWordCd = 0.1f;
        if (!skipped) return fullSentence.Substring(0, (int)Mathf.Clamp((timeCount / oneWordCd), 0, fullSentence.Length));  // set the max number for substring to prevent indexOutOfBound
        else return fullSentence;
    }

    bool sentenceCompleted() {                      // check if current sentence has been completely shown
        bool result = keepTalking(talks[currentIndex]).Length == talks[currentIndex].Length;
        if (!result)
        {
            //if (!talkSE.isPlaying) talkSE.Play();
        }
        //else talkSE.Stop();
        return result;
    }

    string blinkingHint(){                         // turn the last of the santence + "Б@Бе" on/off in every 0.5 sec 
        const float blinkCd = 0.5f;
        if (sentenceCompleted()) {
            if ((int)(timeCount / blinkCd % 2) == 0) { return "Б@Бе"; }
        }
        return "";
    }
}
