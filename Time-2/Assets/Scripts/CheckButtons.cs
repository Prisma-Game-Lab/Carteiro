using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButtons : MonoBehaviour
{

    public GameObject[] Buttons;
    public int maxButtons;
    private int counter = 0;
    public GameObject shadow;
    public GameObject player;

    void Update()
    {
        for(int i = 0; i < Buttons.Length; i++)
        {
            if(Buttons[i].GetComponent<Image>().enabled)
            {
                counter++;
            }
        }
        if(counter == maxButtons)
        {
            shadow.GetComponent<ShadowMovement>().retreatShadow();
            player.GetComponent<GuiltMeter>().stopGuilt();
        }
        else
        {
            counter = 0;
        }
    }
}
