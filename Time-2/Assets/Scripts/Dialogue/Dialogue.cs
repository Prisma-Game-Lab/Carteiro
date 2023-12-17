using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Novo Dialogo", menuName = "Dialogos")]
public class Dialogue : ScriptableObject
{
    public Sprite npc_image;

    public string npc_name;

    [SerializeField]
    public string[] dialogue_stream;
}
