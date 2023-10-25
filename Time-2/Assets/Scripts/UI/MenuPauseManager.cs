using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPauseManager : MonoBehaviour
{
    [SerializeField] private string cenaDoJogoSair;
    [SerializeField] private string cenaDoJogoOpcoes;
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject BotaoPause;
    [SerializeField] private GameObject painelMenuPause;

    public static bool JogoEstaPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(JogoEstaPausado)
            {
                Despausar(); // do ingles "resume"
            } else
            {
                Pausar();
            }
        }
    }

    void Despausar()
    {
        MenuPause.SetActive(false);
        BotaoPause.SetActive(true);
        Time.timeScale = 1.0f;
        JogoEstaPausado = false;
    }

    void Pausar()
    {
        MenuPause.SetActive(true);
        BotaoPause.SetActive(false);
        Time.timeScale = 0f;
        JogoEstaPausado = true;
    }

    //Botões
    public void BotaoPausar()
    {
        Pausar();
    }
    public void Retornar()
    {
        Despausar();
    }

    public void AbrirOpcoes()
    {
        MenuPrincipalManager.cenaRetorno = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(cenaDoJogoOpcoes);
        Despausar();
    }

    public void Sair()
    {
        SceneManager.LoadScene(cenaDoJogoSair);
        Despausar();
    }
}
