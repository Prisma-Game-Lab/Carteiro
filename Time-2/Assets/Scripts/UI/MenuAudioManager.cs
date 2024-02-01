using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public void Sair()
    {
        SceneManager.LoadScene("Menu_Principal");
    }
}
