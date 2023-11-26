using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabiscoScript : MonoBehaviour
{
    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    public void Interruptor()
    {
        if (!pressed)
        {
            LetterDisplay.pressButton();
            pressed = true;
        }
    }
}
