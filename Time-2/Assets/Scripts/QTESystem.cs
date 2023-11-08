using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QTESystem : MonoBehaviour
{
    [SerializeField] private GameObject PassBox;
    [SerializeField] private GameObject Key_W;
    [SerializeField] private GameObject Key_A;
    [SerializeField] private GameObject Key_S;
    [SerializeField] private GameObject Key_D;
    private GameObject CurrentDisplayingKey;

    [SerializeField] private int Tecla;
    [SerializeField] private int WaitingForKey;
    [SerializeField] private int CorrectKey;
    [SerializeField] private int CountingDown;
    [SerializeField] private int NVezes; // Alterar no editor

    [SerializeField] private int i = 0;

    void Update()
    {
        if (i == NVezes)
        {

            PassBox.SetActive(false);
            StopCoroutine(CountDown());
            StopCoroutine(KeyPressing());
            this.enabled = false;
        }
        PassBox.SetActive(true);
        if (WaitingForKey == 0)
        {
            Tecla = Random.Range(1, 5); // de 1 para 4, definindo a nova tecla
            CountingDown = 1;
            StartCoroutine(CountDown());

            if (Tecla == 1) // W
            {
                WaitingForKey = 1;
                CurrentDisplayingKey = Key_W;
                CurrentDisplayingKey.SetActive(true);
            }
            if (Tecla == 2) // A
            {
                WaitingForKey = 1;
                CurrentDisplayingKey = Key_A;
                CurrentDisplayingKey.SetActive(true);
            }
            if (Tecla == 3) // S
            {
                WaitingForKey = 1;
                CurrentDisplayingKey = Key_S;
                CurrentDisplayingKey.SetActive(true);
            }
            if (Tecla == 4) // D
            {
                WaitingForKey = 1;
                CurrentDisplayingKey = Key_D;
                CurrentDisplayingKey.SetActive(true);
            }
        }

        if (Tecla == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (Tecla == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (Tecla == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (Tecla == 4)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        Tecla = 0;
        if (CorrectKey == 1)
        {
            i++;
            CountingDown = 2;
            PassBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Sucesso!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            CurrentDisplayingKey.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }

        if (CorrectKey == 2)
        {
            i = 0;
            CountingDown = 2;
            PassBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Falha!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            CurrentDisplayingKey.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);
        if (CountingDown == 1)
        {
            i++;
            Tecla = 0;
            CountingDown = 2;
            PassBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Falha!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            CurrentDisplayingKey.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

}
