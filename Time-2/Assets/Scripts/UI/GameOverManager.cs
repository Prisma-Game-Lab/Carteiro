using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject TextoGameOver;
    [SerializeField] private string CenaMenuPrincipal;
    private int IndexTexto;

    void Start()
    {
        IndexTexto = Random.Range(1, 14); // random de 1 a 13

        switch(IndexTexto)
        {
            case 1:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Game over!";
                break;
            case 2:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Fim de jogo!";
                break;
            case 3:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Fim de jogo!";
                break;
            case 4:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Você o abandonou...";
                break;
            case 5:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Por que você não volta?";
                break;
            case 6:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Não sente falta?";
                break;
            case 7:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Isso é o que você queria?";
                break;
            case 8:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Na morte, eu descanso, mas o sangue anda solto. Manchando os papéis, documentos fiés.";
                break;
            case 9:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Os meus sonhos foram todos vendidos tão barato que eu nem acredito...";
                break;
            case 10:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Queria querer gritar setecentas mil vezes...";
                break;
            case 11:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Já podaram seus momentos, desviaram seu destino. Seu sorriso de menino, quantas vezes se escondeu?";
                break;
            case 12:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "E a cidade tem braços abertos num cartão postal, com punhos fechados na vida real. Lhes nega oportunidades, mostra a face do mal.";
                break;
            case 13:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Te trago mil rosas roubadas pra desculpar minhas mentiras.";
                break;
        }
    }
    public void TentarDeNovo()
    {
        SceneManager.LoadScene(MenuPrincipalManager.cenaRetorno);
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene(CenaMenuPrincipal);
    }
}
