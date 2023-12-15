using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteList;
    [SerializeField] private GameObject Destinatario;
    private int counter = 0;

    public void changeSprite()
    {
        if(counter < spriteList.Length)
        {
            Destinatario.GetComponent<Image>().sprite = spriteList[counter];
            counter++;
        }
        else
        {
            counter = 0;
        }
    }
}
