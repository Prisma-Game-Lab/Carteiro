using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        moveCharacter(new Vector2(0, 1));
    }

    void moveCharacter(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}