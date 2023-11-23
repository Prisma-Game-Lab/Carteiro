using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiltMeter : MonoBehaviour
{
    [SerializeField] private string CenaGameOver;
    [SerializeField] private int MaxGuilt;
    [SerializeField] private GameObject shadow;
    private float timer;
    private int actualGuilt;
    public int halfGuilt;
    private bool readingGuilt;

    void Start()
    {
        readingGuilt = false;
        startGuilt(10);
    }

    void Update()
    {
        if (readingGuilt)
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                timer = 0f;
                actualGuilt--;
                CheckGuilt();
            }
        }
    }

    public void startGuilt(int newMaxGuilt)
    {
        MaxGuilt = newMaxGuilt;
        halfGuilt = MaxGuilt / 2;
        actualGuilt = MaxGuilt;
        readingGuilt = true;
    }
    public void stopGuilt()
    {
        readingGuilt = false;
    }

    private void CheckGuilt()
    {
        if (actualGuilt == halfGuilt)
        {
            shadow.GetComponent<ShadowMovement>().moveShadow();
        }
        else if (actualGuilt <= 0.0f)
        {
            MenuPrincipalManager.cenaRetorno = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(CenaGameOver);
        }
    }
}
