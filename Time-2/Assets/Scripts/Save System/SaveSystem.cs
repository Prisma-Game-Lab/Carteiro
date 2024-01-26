using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;

public static class SaveSystem
{
    public static void SaveData (LevelProgressionTracker levelTracker)
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "GameData");
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(levelTracker);

        // transformando o arquivo em json
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Data));
        serializer.WriteObject(stream, data);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "GameData");
        if (File.Exists(path))
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Data));
            FileStream stream = new FileStream(path, FileMode.Open);
            
            Data data = serializer.ReadObject(stream) as Data;
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
