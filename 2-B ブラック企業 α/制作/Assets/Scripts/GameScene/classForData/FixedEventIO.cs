using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FixedEventIO : MonoBehaviour
{
    static string filePath = "./Json/.fixedEventData.json";
    public static void saveFixedEvent(FixedEventList inputEvent)
    {
        //filePath = "./Json/.stageDataTest.json";
        string json = JsonUtility.ToJson(inputEvent);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();

    }

    public static FixedEventList loadFixedEvent()
    {
        //filePath = "./Json/.stageData.json";
        //filePath = "./Json/.stageDataTest.json";
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            var stage = JsonUtility.FromJson<FixedEventList>(data);
            return stage;
        }
        return null;
    }
}
