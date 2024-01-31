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
    [SerializeField] private GameObject PainelAjuda;
    [SerializeField] private GameObject BotaoPause;

    public static bool JogoEstaPausado = false;
    private bool JogoIniciado = false;

    void Start()
    {
        JogoEstaPausado = true;
        Time.timeScale = 0f;
        if (PainelAjuda != null) 
        {
             PainelAjuda.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            JogoEstaPausado = false;
            JogoIniciado = true;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && JogoIniciado == true)
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

    //Bot�es
    public void BotaoPausar()
    {
        AudioManager.Instance.PlaySFX("Pause");
        Pausar();
    }
    public void BotaoRetornar()
    {
        Despausar();
    }

    public void BotaoAbrirOpcoes()
    {
        MenuPrincipalManager.cenaRetorno = SceneManager.GetActiveScene().name;
        SceneTransition.Instance.GoToScene("Configurações");
        Despausar();
    }

    public void BotaoSair()
    {
        SceneTransition.Instance.GoToScene("Menu_Principal");
        Despausar();
    }

    public void DespausarInicio()
    {

        PainelAjuda.SetActive(false);
        Time.timeScale = 1.0f;
        JogoEstaPausado = false;
        JogoIniciado = true;
    }
}
