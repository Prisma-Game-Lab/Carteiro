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

    public List<GameObject> buttons;

    public Dictionary<int, Object> botoes;

    public Sprite paragraph;

    public int num_buttons;
    public int buttons_pressed;

    public Vector3[] vector3s;

    private SpriteRenderer _spriteRenderer;
    private GameObject canva;

    //private Button botaoDeTransicao;

    // Start is called before the first frame update
    void Start()
    {
        //botaoDeTransicao  = GetComponent<Button>();

        current = 0; //a q está carregada no script
        inDisplay = 0; ; //a q está carregada no display

        num_buttons = cartas[inDisplay].num_buttons;
        buttons_pressed = cartas[inDisplay].buttons_pressed;

        gameObject.GetComponent<Image>().sprite = cartas[inDisplay].paragraph;

        canva = GameObject.Find("Paragraph");

        for (int i = 0; i < cartas[inDisplay].buttons.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, cartas[inDisplay].buttons[i], transform.rotation) as GameObject;
            
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.SetParent(canva.transform, false);

            buttons.Add(button);
        }
    }

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

    // Update is called once per frame
    void Update()
    {
        if (inDisplay != current)
        {

            gameObject.GetComponent<Image>().sprite = cartas[inDisplay].paragraph;

            //paragraph = cartas[current].paragraph;
            //num_buttons += cartas[current].num_buttons;
            //buttons_pressed = cartas[current].buttons_pressed;

            

           inDisplay = current;
        }
    }
}
