using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OutingEventDataIO : MonoBehaviour
{
    //外出イベントデータ追加するとき専用
    OutingEventList eventsData;

    void Start()
    {
        eventsData = new OutingEventList();
        OutingEvent ev = new OutingEvent();

        ev.id = 1;
        ev.title = "イベント名";
        ev.msg = new string[] { "テスト", "test" };
        ev.effect = new Effect();
        eventsData.events.Add(ev);

        ev = new OutingEvent(2, "イベント2", new string[] { "テスト", "test" }, new Effect(1, 2, 3, 1, 2, 3));
        eventsData.events.Add(ev);

        SaveOutingEvent(eventsData);
        eventsData = LoadOutingEvent();

        Debug.Log(eventsData.events[1].id);
        Debug.Log(eventsData.events[1].title);
    }

    static string filePath = "./Json/Event/.outingEventDataTest.json";
    // jsonとしてデータを保存
    public static void SaveOutingEvent(OutingEventList data)
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
    public static OutingEventList LoadOutingEvent()
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
}
