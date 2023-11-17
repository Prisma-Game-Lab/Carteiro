using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Letter[] cartas;
    public GameObject buttonPrefab;
    private int current;
    private int inDisplay;

    public Dictionary<int, List<Object>> botoesDict = new Dictionary<int, List<Object>>();

    public Sprite paragraph;

    public int num_buttons;
    public int buttons_pressed;

    public Vector3[] vector3s;
    private GameObject canva;

    //private Button botaoDeTransicao;

    //Inicia botões da carta no dicionario
    private void iniciaCartaNoDict(Letter carta)
    {
        List<Object> buttons = new List<Object>();

        for (int i = 0; i < carta.buttons.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, carta.buttons[i], transform.rotation) as GameObject;

            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.SetParent(canva.transform, false);

            buttons.Add(button);
        }

        botoesDict.Add(current, buttons);
    }

    void Start()
    {
        current = 0; //a q está carregada no script
        inDisplay = 0; ; //a q está carregada no display

        num_buttons = cartas[inDisplay].num_buttons;
        buttons_pressed = cartas[inDisplay].buttons_pressed;

        gameObject.GetComponent<Image>().sprite = cartas[inDisplay].paragraph;

        canva = GameObject.Find("Paragraph");

        iniciaCartaNoDict(cartas[current]);
    }

    //Atualiza o indice da carta
    public void trocaCarta()
    {
        if(current == cartas.Length - 1)
        {
            current = 0;
        }
        else
        {
            current++;
        }
    }

    void Update()
    {
        if (inDisplay != current)
        {
            foreach (GameObject botao in botoesDict[inDisplay])
            {
                botao.SetActive(false);
            }

            if (botoesDict.ContainsKey(current))
            {
                foreach (GameObject botao in botoesDict[current])
                {
                    botao.SetActive(true);
                }
            }
            else
            {
                iniciaCartaNoDict(cartas[current]);
            }

           inDisplay = current;

           gameObject.GetComponent<Image>().sprite = cartas[inDisplay].paragraph;
        }
    }
}
