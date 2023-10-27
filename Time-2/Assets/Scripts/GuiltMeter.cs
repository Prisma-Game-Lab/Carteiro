using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiltMeter : MonoBehaviour
{
    public int MaxGuilt;
    public int actualGuilt;
    public GameObject shadow;
    private float timer;
    private float sec = 1.0f;
    [SerializeField] private string CenaGameOver;

    void Start()
    {
        actualGuilt = MaxGuilt;
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
            Debug.Log("Game over");
        }
    }
}
