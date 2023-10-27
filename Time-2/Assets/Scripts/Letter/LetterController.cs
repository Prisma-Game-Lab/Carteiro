using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public int shadow_position;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 2;
        shadow_position = 0;
    }

    private void Update()
    {
        if (shadow_position == 0)
        {
            if(lives == 0)
            {
                //Perdeu o jogo
            }
            lives -= 1;
            shadow_position = 10;
        }
    }

    private void OnMouseDown()
    {
        shadow_position--;
    }
}
