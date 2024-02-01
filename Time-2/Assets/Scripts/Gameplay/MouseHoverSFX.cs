using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverSFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string[] sounds = { "Risco1", "Risco2", "Risco3" };
        string SFX = sounds[Random.Range(0, sounds.Length)];
        AudioManager.Instance.PlaySFX(SFX);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFXC("ButtonHover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AudioManager.Instance.sfxcSource.Stop();
    }
}
