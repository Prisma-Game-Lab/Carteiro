using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private string cenaFase1;
    [SerializeField] private string cenaFase2;
    [SerializeField] private string cenaFase3;
    [SerializeField] private string menuPrincipal;
    [SerializeField] private GameObject bloqueador1;
    [SerializeField] private GameObject bloqueador2;
    [SerializeField] private GameObject bloqueador3;

    void Start()
    {
        //if (level1passou == true)
        //{
        //    bloqueador1.gameObject.SetActive(false);
        //}
        //if (level2passou == true)
        //{
        //    bloqueador2.gameObject.SetActive(false);
        //}
        //if (level3passou == true)
        //{
        //    bloqueador3.gameObject.SetActive(false);
        //}
    }

    public void Voltar()
    {
        SceneManager.LoadScene(menuPrincipal);
    }

    public void Fase1()
    {
        if (bloqueador1.gameObject.activeInHierarchy == false)
        {
            SceneManager.LoadScene(cenaFase1);
        }
    }
    public void Fase2()
    {
        if (bloqueador2.gameObject.activeInHierarchy == false)
        {
            SceneManager.LoadScene(cenaFase2);
        }
    }
    public void Fase3()
    {
        if (bloqueador3.gameObject.activeInHierarchy == false)
        {
            SceneManager.LoadScene(cenaFase3);
        }
    }
}
