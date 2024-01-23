using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        AudioManager.Instance.PlaySFX("CaixaCorreio");
        Object.Destroy(this.gameObject);
    }
}
