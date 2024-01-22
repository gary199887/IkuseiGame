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
    public static bool showingDictionary;
    public static bool showingDictionaryDetail;
    string title = "The Seed: Origin";
    [SerializeField] Text titleText;
    [SerializeField] GameObject buttons;
    [SerializeField] TitleAudioManager titleAudioManager;
    [SerializeField] GameObject titleChara;
    [SerializeField] GameObject titleObj;
    [SerializeField] GameObject dictionaryObj;
    [SerializeField] DictionaryManager dictionaryManager;
    [SerializeField] GameObject dictionaryDetailObj;
    [SerializeField] GameObject dictionaryImgList;
    [SerializeField] Text dictionaryTitleText;
    [SerializeField] Text dictionaryDetailText;
    [SerializeField] SpriteRenderer dictionaryImg;
    [SerializeField] GameObject hintObj;
    [SerializeField] Text hintText;

    [Range(0, 10)]
    [SerializeField] float fadeRange; 

    // Start is called before the first frame update
    void Start()
    {
        // 各変数初期化
        timeCount = 0;
        typingDone = false;
        titleText.text = keepTalking(title);
        buttons.SetActive(false);
        buttonClicked = false;
        dictionaryObj.SetActive(false);
        dictionaryDetailObj.SetActive(false);
        showingDictionary = false;
        hintText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        endGameWithEsc();
        timeCount += Time.deltaTime;
        titleText.text = keepTalking(title) + blinkingHint();
        if (typingDone) {
            if (!buttons.activeSelf) buttons.SetActive(true);
            titleAudioManager.stopKeyboardSE();
            titleAudioManager.playBGM();

            // タイトルキャラフェードイン（仮）
            if (titleChara.transform.position.y < -fadeRange) titleChara.transform.Translate(new Vector2(0, 1.0f * Time.deltaTime));
        }

        if (buttonClicked) {
            titleAudioManager.playConfirmSE();
            buttonClicked = false;
        }
        if (sentenceCompleted())
        {
         typingDone = true;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (showingDictionary)
            {
                titleAudioManager.playCancelSE();
                hideDictionary();
                showTitle();
            }
            else if (showingDictionaryDetail) {
                titleAudioManager.playCancelSE();
                hideDictionaryDetail();
                showDictionary();
            }
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

    public void showTitle() {
        titleObj.SetActive(true);
    }
    public void hideTitle()
    {
        titleObj.SetActive(false);
    }

    public void showDictionary() {
        showingDictionary = true;
        dictionaryObj.SetActive(true);
        hideTitle();
    }

    public void hideDictionary()
    {
        showingDictionary = false;
        dictionaryObj.SetActive(false);
        hintText.text = "";
    }

    public void showDictionaryDetail(int id) {
        Ending choosenEnding = dictionaryManager.endingList.endings[id];
        dictionaryImg.sprite = dictionaryManager.sprites[id];
        float scale = dictionaryManager.resizeSprite(dictionaryManager.sprites[id]) * 4.5f;
        dictionaryImg.gameObject.transform.localScale = new Vector2(scale, scale);
        string detailText = "";
        foreach (string str in choosenEnding.description) 
            detailText += str + "\n\n\n";
        dictionaryDetailText.text = detailText;
        dictionaryTitleText.text = choosenEnding.name;

        dictionaryDetailObj.SetActive(true);
        dictionaryImgList.SetActive(false);
        hintObj.SetActive(false);
        showingDictionaryDetail = true;
        showingDictionary = false;
    }

    public void hideDictionaryDetail() {
        dictionaryTitleText.text = "エンディング図鑑";
        dictionaryDetailObj.SetActive(false);
        dictionaryImgList.SetActive(true);
        hintObj.SetActive(true);
        showingDictionaryDetail = false;
        showingDictionary = true;
        hintText.text = "";
    }

    public bool checkIfEndingCleared(int id) {
        bool result = dictionaryManager.endingList.endings[id].cleared;
        return result;
    }

    public void showHint(int id)
    {
        hintText.text = dictionaryManager.endingList.endings[id].hint;
    }
}
