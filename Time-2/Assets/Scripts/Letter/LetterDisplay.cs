using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LetterDisplay : MonoBehaviour
{
    public Letter carta;
    public GameObject buttonPrefab;

    public List<GameObject> buttons;

    public Sprite sprite;
    public int num_buttons;
    public int buttons_pressed;

    public Vector3[] vector3s;

    private SpriteRenderer _spriteRenderer;

    private GameObject canva;


    // Start is called before the first frame update
    void Start()
    {
        sprite = carta.sprite;
        num_buttons = carta.num_buttons;
        buttons_pressed = carta.buttons_pressed;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;

        canva = GameObject.Find("Canvas");

        for (int i = 0; i < carta.buttons.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, carta.buttons[i], transform.rotation);
            button.transform.localScale = new Vector3(1, 1, 1);
            buttons.Add(button);
            button.transform.SetParent(canva.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
