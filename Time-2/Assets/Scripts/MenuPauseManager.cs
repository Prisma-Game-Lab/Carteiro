using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPauseManager : MonoBehaviour
{
    [SerializeField] private string cenaAtual;
    [SerializeField] private string cenaDoJogoSair;
    [SerializeField] private string cenaDoJogoOpcoes;
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject painelMenuPause;
    [SerializeField] private GameObject painelMenuOpcoes;

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
        Time.timeScale = 1.0f;
        JogoEstaPausado = false;
    }

    void Pausar()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0f;
        JogoEstaPausado = true;
    }

    //Botões
    public void Retornar()
    {
        MenuPause.SetActive(false);
    }

    public void AbrirOpcoes()
    {
        Despausar();
        MenuPrincipalManager.cenaRetorno = cenaAtual;
        SceneManager.LoadScene(cenaDoJogoOpcoes);
    }

    public void Sair()
    {
        Despausar();
        SceneManager.LoadScene(cenaDoJogoSair);
    }
}
