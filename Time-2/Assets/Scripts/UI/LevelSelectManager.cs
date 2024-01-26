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
    [SerializeField] private GameObject bloqueador2;
    [SerializeField] private GameObject bloqueador3;

    void Start()
    {
        if(PlayerPrefs.GetInt("Level1Completo", 1) == 2)
        {
            bloqueador2.gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Level2Completo", 1) == 2)
        {
            bloqueador3.gameObject.SetActive(false);
        }
    }

    public void Voltar()
    {
        SceneManager.LoadScene(menuPrincipal);
    }

    public void Fase1()
    {
        SceneManager.LoadScene(cenaFase1);

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
