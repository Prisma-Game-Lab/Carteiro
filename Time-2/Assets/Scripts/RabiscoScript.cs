using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabiscoScript : MonoBehaviour
{
    public int total_buttons;
    public static int clicked_buttons;


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
            //imagem.enabled = false;
            Debug.Log("Ja foi");
        }
        else
        {
            imagem.enabled = true;
            clicked_buttons++;
            Debug.Log(clicked_buttons);
        }
    }
}
