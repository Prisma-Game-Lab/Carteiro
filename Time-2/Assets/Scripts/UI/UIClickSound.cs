using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSound : MonoBehaviour
{
    public void ClickSound()
    {
        AudioManager.Instance.PlaySFX("UI");
    }
}
