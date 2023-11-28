using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName; // nome do arquivo de mem�ria!!

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance {  get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("H� mais de um DataPersistenceManager nessa cena!");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        CarregarJogo();
    }

    public void NovoJogo()
    {
        this.gameData = new GameData();
    }
    
    public void CarregarJogo()
    {
        // Carrega qualquer mem�ria salva usando um data handler
        this.gameData = dataHandler.Load();

        // se nenhum dado for carreg�vel, iniciar novo jogo
        if (this.gameData != null)
        {
            Debug.Log("Nenhuma save encontrada, inicializando uma nova save!");
            NovoJogo();
        }

        // joga os mem�ria carregados para outros scripts que precisam
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SalvarJogo()
    {
        // passa a mem�ria para outros scripts para atualizarem-na
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // salva esses dados para o arquivo usando o data handler
        dataHandler.Save(gameData);
    }

    private void FecharoJogo()
    {
        SalvarJogo();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
