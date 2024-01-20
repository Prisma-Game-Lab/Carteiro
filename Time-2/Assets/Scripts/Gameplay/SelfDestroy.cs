using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Object.Destroy(this.gameObject);
    }
}
