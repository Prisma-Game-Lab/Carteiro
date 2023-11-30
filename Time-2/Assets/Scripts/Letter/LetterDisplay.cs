using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public LetterList[] cartas;
    public GameObject buttonPrefab;

    private int currentParagraph; //paragrafo q est� carregado no script
    private int currentLetter; //A carta atual do nivel 
    private int inDisplay; //paragrafo carregado no display

    public Dictionary<int, List<Object>> botoesDict = new Dictionary<int, List<Object>>(); //Dicionario dos botoes

    public Sprite paragraph; //Imagem do paragrafo

    [SerializeField]
    public int num_buttons; //Numero total de botoes da carta atual
    [SerializeField]
    public static int buttons_pressed; //Numero de botoes que ja foram pressionados

    private GameObject canva;

    [SerializeField] private int[] lettersGuilt;
    public GameObject player;

    //Inicia bot�es da carta no dicionario
    private void iniciaCartaNoDict(Letter carta)
    {
        List<Object> buttons = new List<Object>();

        for (int i = 0; i < carta.buttons.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, carta.buttons[i], transform.rotation) as GameObject;

            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.SetParent(canva.transform, false);
            button.AddComponent<MouseHoverSFX>();
            buttons.Add(button);
        }

        botoesDict.Add(currentParagraph, buttons);
    }

    void Start()
    {
        currentParagraph = 0;
        inDisplay = 0; ;

        currentLetter = 0;
        num_buttons = 0;

        gameObject.GetComponent<Image>().sprite = cartas[currentLetter].carta[inDisplay].paragraph;

        canva = GameObject.Find("Paragraph");

        iniciaCartaNoDict(cartas[currentLetter].carta[currentParagraph]);

        for(int i = 0; i < cartas[currentLetter].carta.Length; i++)
        {
            num_buttons += cartas[currentLetter].carta[i].buttons.Length;
        }

        player.GetComponent<GuiltMeter>().startGuilt(lettersGuilt[currentLetter]);
        Debug.Log(lettersGuilt[currentLetter]);
    }

    //Atualiza o indice da carta
    public void trocaParagrafo()
    {
        if(currentParagraph == cartas.Length - 1)
        {
            currentParagraph = 0;
        }
        else
        {
            currentParagraph++;
        }
    }

    //Atualiza o display no update
    public void atualizaDisplay()
    {
        foreach (GameObject botao in botoesDict[inDisplay])
        {
            botao.SetActive(false);
        }

        if (botoesDict.ContainsKey(currentParagraph))
        {
            foreach (GameObject botao in botoesDict[currentParagraph])
            {
                botao.SetActive(true);
            }
        }
        else
        {
            iniciaCartaNoDict(cartas[currentLetter].carta[currentParagraph]);
        }

        inDisplay = currentParagraph;

        gameObject.GetComponent<Image>().sprite = cartas[currentLetter].carta[inDisplay].paragraph;
    }

    //Troca a carta quando todos os botoes forem pressionados
    public void atualizaCarta()
    {
        player.GetComponent<GuiltMeter>().stopGuilt();

        for (int i = 0; i < cartas[currentLetter].carta.Length; i++)
        {
            for (int j = 0; j < cartas[currentLetter].carta.Length; j++) {
                foreach (GameObject botao in botoesDict[j])
                {
                    Destroy(botao);
                }
                botoesDict.Remove(j);
            }
        }

        currentLetter++;

        currentParagraph = 0;
        inDisplay = 0; ;

        num_buttons = 0;
        buttons_pressed = 0;

        gameObject.GetComponent<Image>().sprite = cartas[currentLetter].carta[inDisplay].paragraph;

        canva = GameObject.Find("Paragraph");

        iniciaCartaNoDict(cartas[currentLetter].carta[currentParagraph]);

        for (int i = 0; i < cartas[currentLetter].carta.Length; i++)
        {
            num_buttons += cartas[currentLetter].carta[i].buttons.Length;
        }

        player.GetComponent<GuiltMeter>().startGuilt(lettersGuilt[currentLetter]);
    }

    void Update()
    {
        if (inDisplay != currentParagraph && inDisplay + 1 < cartas[currentLetter].carta.Length)
        {
            atualizaDisplay();
        }

        if (buttons_pressed == num_buttons && currentLetter + 1 < cartas.Length)
        {
            atualizaCarta();
        }
    }

    public static void pressButton()
    {
        buttons_pressed++;
    }
}


//Classe wraper utilizada para podermos ocupar os arrays a partir do inspector
[System.Serializable]
public class LetterList
{
    public Letter[] carta;
}