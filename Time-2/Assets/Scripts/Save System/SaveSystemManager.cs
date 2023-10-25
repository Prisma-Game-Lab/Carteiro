using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemManager : MonoBehaviour
{
    private GameData gameData;
    public static SaveSystemManager instancia {  get; private set; }

    private void Awake()
    {
        if (instancia != null)
        {
            Debug.LogError("Há mais de um SaveSystemManager nessa cena!");
        }
        instancia = this;
    }

    private void Start()
    {
        CarregarJogo();
    }

    public void NovoJogo()
    {
        this.gameData = new GameData();
    }
    
    public void CarregarJogo()
    {
        if (this.gameData != null)
        {
            Debug.Log("Nenhuma save encontrada, inicializando uma nova save!");
            NovoJogo();
        }
    }

    public void SalvarJogo()
    {

    }

    private void FecharoJogo()
    {
        SalvarJogo();
    }
}
