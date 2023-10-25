using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{
    [SerializeField] private GameObject DisplayBox;
    [SerializeField] private GameObject PassBox;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;

    void Update()
    {
        if (WaitingForKey == 0)
        {
            QTEGen = Random.Range(1, 5); // de 1 para 4, definindo a nova tecla
            CountingDown = 1;
            StartCoroutine(CountDown());

            if (QTEGen == 1) // W
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[W]";
            }
            if (QTEGen == 1) // A
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[A]";
            }
            if (QTEGen == 1) // S
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[S]";
            }
            if (QTEGen == 1) // D
            {
                WaitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[D]";
            }
        }

        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 0;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        QTEGen = 8;
        if (CorrectKey == 1)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "Sucesso!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }

        if (CorrectKey == 2)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "Falha!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
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
            QTEGen = 8;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "Falha!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }

}
