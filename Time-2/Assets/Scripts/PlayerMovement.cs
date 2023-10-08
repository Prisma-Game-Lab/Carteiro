using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float PlayerSpeed = 1.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move((Vector2.right * PlayerSpeed) * Time.deltaTime);
    }
}
