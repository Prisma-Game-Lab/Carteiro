using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Letter carta;

    public Sprite sprite;
    public int num_buttons;
    public int buttons_pressed;

    public Vector3[] vector3s;

    private SpriteRenderer _spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        sprite = carta.sprite;
        num_buttons = carta.num_buttons;
        buttons_pressed = carta.buttons_pressed;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;

        for (int i = 0; i < carta.buttons.Length; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
