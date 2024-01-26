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
    [SerializeField] private GameObject PainelCreditos;
    public static string cenaRetorno;

    public void Jogar()
    {
        SceneManager.LoadScene(cenaDoJogoJogar);
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
    }

    public void FecharAjuda()
    {
        PainelAjuda.SetActive(false);
    }

    public void Creditos()
    {
        PainelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        PainelCreditos.SetActive(false);
    }
}
