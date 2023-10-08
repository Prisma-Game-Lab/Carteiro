using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string cenaAtual;
    [SerializeField] private string cenaDoJogoJogar;
    [SerializeField] private string cenaDoJogoOpcoes;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelMenuOpcoes;
    public static string cenaRetorno;
    public void Jogar()
    {
        SceneManager.LoadScene(cenaDoJogoJogar);
    }

    public void AbrirOpcoes()
    {
        cenaRetorno = cenaAtual;
        SceneManager.LoadScene(cenaDoJogoOpcoes);
    }


    public void Sair()
    {
        Debug.Log("Sair do jogo"); // sair não funciona no edito, por isso a mensagem de debug
        Application.Quit();
    }
}
