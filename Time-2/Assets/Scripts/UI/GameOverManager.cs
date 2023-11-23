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
        IndexTexto = Random.Range(1, 3); // random de 1 a 2

        switch(IndexTexto)
        {
            case 1:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Game over!";
                break;
            case 2:
                TextoGameOver.GetComponent<TMPro.TextMeshProUGUI>().text = "Fim de jogo!";
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
