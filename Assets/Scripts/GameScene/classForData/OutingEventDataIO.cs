using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OutingEventDataIO : MonoBehaviour
{
    //�O�o�C�x���g�f�[�^�ǉ�����Ƃ���p
    OutingEventList eventsData;

    void Start()
    {
        eventsData = new OutingEventList();
        OutingEvent ev = new OutingEvent();

        ev.id = 1;
        ev.title = "�C�x���g��";
        ev.msg = new string[] { "�e�X�g", "test" };
        ev.effect = new Effect();
        eventsData.events.Add(ev);

        ev = new OutingEvent(2, "�C�x���g2", new string[] { "�e�X�g", "test" }, new Effect(1, 2, 3, 1, 2, 3));
        eventsData.events.Add(ev);

        SaveOutingEvent(eventsData);
        eventsData = LoadOutingEvent();

        Debug.Log(eventsData.events[1].id);
        Debug.Log(eventsData.events[1].title);
    }

    static string filePath = "./Json/Event/.outingEventDataTest.json";
    // json�Ƃ��ăf�[�^��ۑ�
    public static void SaveOutingEvent(OutingEventList data)
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
    public static OutingEventList LoadOutingEvent()
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
}
