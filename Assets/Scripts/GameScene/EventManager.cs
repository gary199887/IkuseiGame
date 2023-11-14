using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    static string filePath = "./Json/Event/.eventData.json";
    // json�Ƃ��ăf�[�^��ۑ�
    public static void SaveEvents(EventList data)
    {
        //if (!File.Exists(filePath))   // �t�@�C����������ΐ���
        {
            string json = JsonUtility.ToJson(data);
            StreamWriter streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
    // json�t�@�C���ǂݍ���
    public static EventList LoadEvents()
    {
        //filePath = "./Json/Event/.eventData.json";
        if (!File.Exists(filePath)) return null;
        StreamReader rd = new StreamReader(filePath);           // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<EventList>(json);           // json�t�@�C�����^�ɖ߂��ĕԂ�
    }
}
