using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    static string filePath = "./Json/Event/.eventData.json";
    // jsonとしてデータを保存
    public static void SaveEvents(EventList data)
    {
        //if (!File.Exists(filePath))   // ファイルが無ければ生成
        {
            string json = JsonUtility.ToJson(data);
            StreamWriter streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
    // jsonファイル読み込み
    public static EventList LoadEvents()
    {
        //filePath = "./Json/Event/.eventData.json";
        if (!File.Exists(filePath)) return null;
        StreamReader rd = new StreamReader(filePath);           // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<EventList>(json);           // jsonファイルを型に戻して返す
    }
}
