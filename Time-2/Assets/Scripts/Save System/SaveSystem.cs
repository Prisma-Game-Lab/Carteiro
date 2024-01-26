using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;

public static class SaveSystem
{
    public static void SaveData (LetterDisplay levelTracker)
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "GameData");
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(levelTracker);

        // transformando o arquivo em json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GameData));
        serializer.WriteObject(stream, data);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "GameData");
        if (File.Exists(path))
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GameData));
            FileStream stream = new FileStream(path, FileMode.Open);
            
            GameData data = serializer.ReadObject(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Arquivo de save não encontrado em " + path);
            return null;
        }
    }
}
