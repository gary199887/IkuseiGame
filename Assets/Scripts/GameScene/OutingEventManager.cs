using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OutingEventManager : MonoBehaviour
{
    [SerializeField] GameObject outingEvent;
    [SerializeField] Image eventImage;
    [SerializeField] Sprite[] eventSprites;
    int happeningEvent;

    static string filePath = "./Json/Event/.outingEventDataTest.json";
    // jsonとしてデータを保存
    public static void SaveEvents(OutingEventList data)
    {
        if (!File.Exists(filePath))   // ファイルが無ければ生成
        {
            string json = JsonUtility.ToJson(data);
            StreamWriter streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
    // jsonファイル読み込み
    public static OutingEventList LoadEvents()
    {
        filePath = "./Json/Event/.outingEventData.json";
        if (File.Exists(filePath))
        {
            StreamReader rd = new StreamReader(filePath);           // ファイル読み込み指定
            string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
            rd.Close();                                             // ファイル閉じる

            return JsonUtility.FromJson<OutingEventList>(json);           // jsonファイルを型に戻して返す
        }
        return null;
    }

    private void Start()
    {
        outingEvent.SetActive(false);
    }

    private void Update()
    {
        if (outingEvent.activeSelf) {
            CommonFunctions.twoImgAnimation(eventImage, eventSprites[happeningEvent * 2], eventSprites[happeningEvent * 2 + 1]);
        }
    }

    public void ShowOutingEvent(int eventNum)
    {
        happeningEvent = eventNum;
        outingEvent.SetActive(true);
        eventImage.sprite = eventSprites[eventNum];
    }

    public void CloseOutingEvent()
    {
        outingEvent.SetActive(false);
    }
}
