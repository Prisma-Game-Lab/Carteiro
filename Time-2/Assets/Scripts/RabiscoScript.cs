using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabiscoScript : MonoBehaviour
{
    public Image imagem;
    // Start is called before the first frame update
    void Start()
    {
        imagem = GetComponent<Image>();
    }

    public void Interruptor()
    {
        if (imagem.isActiveAndEnabled)
        {
            imagem.enabled = false;
            Debug.Log("Jair bolsonaro");
        }
        else
        {
            imagem.enabled = true;
            Debug.Log("Eu só quero...");
        }
    }
}
