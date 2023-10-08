using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public void Sair()
    {
        SceneManager.LoadScene(MenuPrincipalManager.cenaRetorno);
    }
}
