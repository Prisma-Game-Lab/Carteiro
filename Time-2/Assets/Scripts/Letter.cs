using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Carta", menuName = "Cartas")]
public class Letter : ScriptableObject
{
    public Sprite sprite;

    public int num_buttons;
    public int buttons_pressed;

    [SerializeField]
    public Vector3[] buttons;

    public int coisa;

}
