using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OutingEventManager : MonoBehaviour
{
    static string filePath = "./Json/Event/.outingEventData.json";
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
        //filePath = "./Json/Event/.eventData.json";
        if (!File.Exists(filePath)) return null;
        StreamReader rd = new StreamReader(filePath);           // �t�@�C���ǂݍ��ݎw��
        string json = rd.ReadToEnd();                           // �t�@�C�����e�S�ēǂݍ���
        rd.Close();                                             // �t�@�C������

        return JsonUtility.FromJson<OutingEventList>(json);           // json�t�@�C�����^�ɖ߂��ĕԂ�
    }
}
