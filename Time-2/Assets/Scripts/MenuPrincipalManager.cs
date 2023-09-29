using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string cenaDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelMenuOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene(cenaDoJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelMenuOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {        
        painelMenuOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void Sair()
    {
        Debug.Log("Sair do jogo"); // sair não funciona no edito, por isso a mensagem de debug
        Application.Quit();
    }
}
