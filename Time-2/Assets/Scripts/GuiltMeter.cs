using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiltMeter : MonoBehaviour
{
    [SerializeField] private string CenaGameOver;
    [SerializeField] private int MaxGuilt;
    public GameObject shadow;
    private float timer;
    private float sec = 1.0f;
    private int actualGuilt;
    public int halfGuilt;

    void Start()
    {
        actualGuilt = MaxGuilt;
        halfGuilt = MaxGuilt / 2;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= sec)
        {
            timer = 0f;
            actualGuilt--;
            CheckGuilt();
        }
    }

    void CheckGuilt()
    {
        if (actualGuilt == MaxGuilt / 2)
        {
            shadow.GetComponent<ShadowMovement>().moveShadow();
        }
        else if (actualGuilt <= 0.0f)
        {
            SceneManager.LoadScene(CenaGameOver);
        }
    }
}
