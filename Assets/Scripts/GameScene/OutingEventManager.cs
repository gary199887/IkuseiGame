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
    // json�Ƃ��ăf�[�^��ۑ�
    public static void SaveEvents(OutingEventList data)
    {
        if (!File.Exists(filePath))   // �t�@�C����������ΐ���
        {
            string json = JsonUtility.ToJson(data);
            StreamWriter streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
    // json�t�@�C���ǂݍ���
    public static OutingEventList LoadEvents()
    {
        filePath = "./Json/Event/.outingEventData.json";
        if (File.Exists(filePath))
        {
            StreamReader rd = new StreamReader(filePath);           // �t�@�C���ǂݍ��ݎw��
            string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
            rd.Close();                                             // �t�@�C������

            return JsonUtility.FromJson<OutingEventList>(json);           // json�t�@�C�����^�ɖ߂��ĕԂ�
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
