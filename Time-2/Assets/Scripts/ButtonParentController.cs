using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonParentController : MonoBehaviour
{
    public GameObject[] button_prefabs;
    public GameObject[] buttons;

    public static int buttons_pressed;

    void Start()
    {
        buttons = new GameObject[button_prefabs.Length];
        for(int i = 0; i < button_prefabs.Length; i++)
        {
            buttons[i] = Instantiate(button_prefabs[i]) as GameObject;
        }
    }

    public static void UpdateCounter(GameObject button)
    {
        buttons_pressed += 1;
        button.SetActive(false);
    }
}
