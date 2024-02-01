using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    [SerializeField] private string MenuPrincipal;
    [SerializeField] private GameObject Quadro1;
    [SerializeField] private GameObject Blur;
    [SerializeField] private GameObject Botao;
    public void Avancar()
    {
           Quadro1.SetActive(true);
           Blur.SetActive(true);
        Botao.SetActive(true);
    }

    public void Sair()
    {
        SceneManager.LoadScene(MenuPrincipal);
    }
}
