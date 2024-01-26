using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private string CenaVitoria; // tela de vitoria

    [SerializeField] private GameObject CaixaCorreio;
    [SerializeField] private GameObject CaixaSpawn;

    //Inicia botoes da carta no dicionario
    private void iniciaCartaNoDict(Letter carta)
    {
        List<Object> buttons = new List<Object>();

        for (int i = 0; i < carta.buttons.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, carta.buttons[i], transform.rotation) as GameObject;

            button.transform.localScale = new Vector3(3, 0.5f, 1);
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

        if (player)
        {
            player.GetComponent<GuiltMeter>().startGuilt(lettersGuilt[currentLetter]);
            Debug.Log(lettersGuilt[currentLetter]);
        }
    }

    //Funcao auxiliar que destroi os botoes da carta e limpa o dicionario
    private void destroiBotoes()
    {
        for (int i = 0; i < cartas[currentLetter].carta.Length; i++)
        {
            foreach (GameObject botao in botoesDict[i])
            {
                Destroy(botao);
            }
            botoesDict.Remove(i);
        }
    }

    //Atualiza o indice da carta
    public void trocaParagrafo()
    {
        if(currentParagraph == cartas[currentLetter].carta.Length - 1)
        {
            currentParagraph = 0;
        }
        else
        {
            currentParagraph++;
        }
    }

    //Atualiza o display no update
    private void atualizaDisplay()
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

        destroiBotoes();

        currentLetter++;

        currentParagraph = 0;
        inDisplay = 0;

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
        if (inDisplay != currentParagraph)
        {
            atualizaDisplay();
        }

        if (buttons_pressed == num_buttons && currentLetter + 1 < cartas.Length)
        {
            GameObject caixa;
            caixa = Instantiate(CaixaCorreio, new Vector3(CaixaSpawn.transform.position.x, CaixaSpawn.transform.position.y, 0), Quaternion.identity);
            Debug.Log("MudaCarta");
            atualizaCarta();
        }
        // vitoria do nivel
        else if(buttons_pressed == num_buttons && currentLetter + 1 >= cartas.Length)
        {
            SceneManager.LoadScene(CenaVitoria);
        }
    }

    //Funcao estatica chamada pelos rabiscos, utilizada para controle dos botoes pressionados
    public static void pressButton()
    {
        buttons_pressed++;
    }

    //Funcao chamada quando o jogador perde, reinicia a carta na fase
    public void resetaCarta()
    {
        destroiBotoes();

        currentLetter = 0;
        inDisplay = 0;
        currentParagraph = 0;

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
}


//Classe wraper utilizada para podermos ocupar os arrays a partir do inspector
[System.Serializable]
public class LetterList
{
    public Letter[] carta;
}