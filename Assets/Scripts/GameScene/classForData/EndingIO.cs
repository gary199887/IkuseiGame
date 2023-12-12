using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndingIO : MonoBehaviour
{
    static string filePath = "./Json/Ending/.endingData.json";
    public static void saveEnding(EndingList inputEvent)
    {
        string json = JsonUtility.ToJson(inputEvent);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
    }

    public static EndingList loadEnding()
    {
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            var stage = JsonUtility.FromJson<EndingList>(data);
            return stage;
        }
        return null;
    }
}
