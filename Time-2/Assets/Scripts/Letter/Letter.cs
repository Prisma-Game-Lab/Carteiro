using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nova Carta", menuName = "Cartas")]
public class Letter : ScriptableObject
{
    public Sprite paragraph;

    [SerializeField]
    public Vector3[] buttons;

}
