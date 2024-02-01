//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using System.IO;

//public class FileDataHandler
//{
//    private string dataDirPath = ""; // path do diretório da memória do jogo
//    private string dataFileName = ""; // autoexplicativo

//    public FileDataHandler(string dataDirPath, string dataFileName)
//    {
//        this.dataDirPath = dataDirPath;
//        this.dataFileName = dataFileName;
//    }

//    public GameData Load()
//    {
//        string fullPath = Path.Combine(dataDirPath, dataFileName);
//        GameData loadedData = null;
//        if (File.Exists(fullPath))
//        {
//            try
//            {
//                // carrega a memória/dados serializada do arquivo
//                string DataToLoad = "";
//                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
//                {
//                    using (StreamReader reader = new StreamReader(stream))
//                    {
//                        DataToLoad = reader.ReadToEnd();
//                    }
//                }

//                // deserializar os dados de JSON para C# de volta
//                loadedData = JsonUtility.FromJson<GameData>(DataToLoad);
//            }
//            catch (Exception e)
//            {
//                Debug.LogError("Erro ocorreu ao tentar carregar os dados do arquivo: " + fullPath + e);
//            }
//        }
//        return loadedData;
//    }

//    public void Save(GameData data)
//    {
//        string fullPath = Path.Combine(dataDirPath, dataFileName);
//        try
//        {
//            // cria o path para o diretório caso ainda não exista
//            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

//            // serializar os dados do jogo em C# para JSON
//            string dataToStore = JsonUtility.ToJson(data, true); // dataToStore = dados para guardar

//            // escreve os dados serializados para o arquivo
//            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
//            {
//                using (StreamWriter writer = new StreamWriter(stream))
//                {
//                    writer.Write(dataToStore);
//                }
//            }
//        }
//        catch (Exception e) 
//        {
//            Debug.LogError("Erro ao tentar salvar memória no arquivo: " + fullPath + "\n" + e);
//        }
//    }
//}
