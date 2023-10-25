using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]   
public class Letter : ScriptableObject
{
    public int num_buttons;

    public new string name;
    public string description;

    public ButtonParentController button_controller;
    public LetterController letter_controller;

}
