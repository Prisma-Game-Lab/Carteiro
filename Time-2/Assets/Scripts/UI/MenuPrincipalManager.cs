using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string cenaDoJogoJogar;
    [SerializeField] private string cenaDoJogoOpcoes;
    [SerializeField] private GameObject PainelAjuda;
    [SerializeField] private static bool AjudaApareceu = false;
    public static string cenaRetorno;
    public void Jogar()
    {
        if ( AjudaApareceu == true)
        {   
            SceneManager.LoadScene(cenaDoJogoJogar);
            MenuPauseManager.JogoEstaPausado = true;
            Time.timeScale = 0f;
        }
        else
        {
            PainelAjuda.SetActive(true);
            AjudaApareceu = true;
        } 
    }

    public void AbrirOpcoes()
    {
        cenaRetorno = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(cenaDoJogoOpcoes);
    }


    public void Sair()
    {
        Debug.Log("Sair do jogo"); // sair não funciona no edito, por isso a mensagem de debug
        Application.Quit();
    }

    public void Ajuda()
    {
        PainelAjuda.SetActive(true);
        AjudaApareceu = true;
    }

    public void FecharAjuda()
    {
        PainelAjuda.SetActive(false);
    }

}
