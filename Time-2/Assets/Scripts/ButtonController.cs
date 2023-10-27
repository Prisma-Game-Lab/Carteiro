using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update

    public ButtonController(Vector3 vector)
    {
        Instantiate(this, vector, transform.rotation);
    }

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    // Detecta clique do mouse
    private void OnMouseDown()
    {
        _spriteRenderer.enabled = true;
        //ButtonParentController.UpdateCounter();
    }
}
