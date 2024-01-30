using System.IO;
using UnityEngine;

public class SaveIO : MonoBehaviour
{
    static string filePath = "./Json/Save/.saveData.json";
    
    public static void DataSave(SaveData input)
    {
        if (Directory.Exists("./Json/Save/")==false)
        {
            System.IO.Directory.CreateDirectory("./Json/Save/ ");
        }
        string json = JsonUtility.ToJson(input);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);   streamWriter.Flush();
        streamWriter.Close();
    }

    public static SaveData DataLoad()
    {
        if (File.Exists(filePath))
        {
            string data=File.ReadAllText(filePath);
            var play = JsonUtility.FromJson<SaveData>(data);
            return play;
        }
        return null;
    }
}
