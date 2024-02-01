using UnityEngine;

public class UIClickSound : MonoBehaviour
{
    public void ClickSound()
    {
        AudioManager.Instance.PlaySFX("CliqueUI");
    }
}
