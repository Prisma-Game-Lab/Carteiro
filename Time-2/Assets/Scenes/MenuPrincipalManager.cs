using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour

{
    [SerializeField] private string nomeDoLevel; 
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;


    public void Jogar() // esse m�todo ser� acionado quando o bot�o de jogar for pressionado
    {
        SceneManager.LoadScene(nomeDoLevel);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo"); // sair do jogo n funciona no editor
        Application.Quit();
    }

}
