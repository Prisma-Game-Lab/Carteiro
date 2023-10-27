using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiltMeter : MonoBehaviour
{
    public int MaxGuilt;
    public int actualGuilt;
    public GameObject shadow;
    private float timer;
    private float sec = 1.0f;

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
            print("Shadow");
            shadow.GetComponent<ShadowMovement>().moveShadow();
        }
        else if (MaxGuilt <= 0.0f)
        {
            print("Game over");
        }
    }
}
