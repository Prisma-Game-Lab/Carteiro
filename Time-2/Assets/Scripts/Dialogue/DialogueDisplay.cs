using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    public List<Dialogue> dialogue_list;

    public Image npc_image;

    [SerializeField]
    public GameObject npc;
    [SerializeField]
    public GameObject dialogue;

    private TextMeshProUGUI npc_name;
    private TextMeshProUGUI dialogue_text;

    private int dialogue_list_length;

    private Dialogue atual;

    private string[] current_dialogue_stream;

    private int current_dialogue;
    private int current_dialogue_length;
    private int current_string; 

    // Start is called before the first frame update
    void Start()
    {
        npc_name = npc.GetComponent<TMPro.TextMeshProUGUI>();
        dialogue_text = dialogue.GetComponent<TextMeshProUGUI>();

        dialogue_list_length = dialogue_list.Count;

        current_dialogue = 0;
        atual = dialogue_list[current_dialogue];

        current_string = 0;
        current_dialogue_stream = atual.dialogue_stream;
        current_dialogue_length = current_dialogue_stream.Length;

        npc_name.text = atual.npc_name;
        dialogue_text.text = current_dialogue_stream[current_string];

        npc_image.sprite = atual.npc_image;
    }

    private void atualizaDialogo()
    {
        if (current_dialogue + 1 < dialogue_list_length)
        {
            current_dialogue += 1;

            atual = dialogue_list[current_dialogue];

            current_string = 0;
            current_dialogue_stream = atual.dialogue_stream;
            current_dialogue_length = current_dialogue_stream.Length;

            npc_name.text = atual.npc_name;
            dialogue_text.text = current_dialogue_stream[current_string];

            npc_image.sprite = atual.npc_image;
        }

        else
        {
            //TO DO: pedir ajuda pro Bento pra fazer a transicao de cena
            print("Eu queria mudar eu queria mudar");
        }
    }

    public void atualizaLinhaDialogo()
    {
        if(current_string + 1 < current_dialogue_length)
        {
            current_string += 1;
            dialogue_text.text = current_dialogue_stream[current_string];
        }

        else
        {
            atualizaDialogo();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
