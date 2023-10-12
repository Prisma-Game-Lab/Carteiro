using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        life--;
        print("Ai ai socorro meu deus");
    }
}
