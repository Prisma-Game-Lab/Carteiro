using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiltMeter : MonoBehaviour
{
    [SerializeField] private string CenaGameOver;
    [SerializeField] private int MaxGuilt;
    [SerializeField] private GameObject shadow;
    [SerializeField] private GameObject QTE;
    private float timer;
    private int actualGuilt;
    public int halfGuilt;
    private bool readingGuilt;
    public static int QTECount = 0;

    void Start()
    {
        readingGuilt = false;
    }

    void Update()
    {
        if (readingGuilt)
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                timer = 0f;
                actualGuilt--;
                CheckGuilt();
            }
        }
    }

    public void startGuilt(int newMaxGuilt)
    {
        MaxGuilt = newMaxGuilt;
        halfGuilt = MaxGuilt / 2;
        actualGuilt = MaxGuilt;
        readingGuilt = true;
    }
    public void stopGuilt()
    {
        readingGuilt = false;
        shadow.GetComponent<ShadowMovement>().retreatShadow();
        QTESystem.erros = 0;
        QTESystem.i = 0;
    }

    private void CheckGuilt()
    {
        if (actualGuilt == halfGuilt)
        {
            shadow.GetComponent<ShadowMovement>().moveShadow();
        }
        else if(actualGuilt == 1 && QTECount < 2)
        {
            readingGuilt = false;
            AudioManager.Instance.sfxSource.Stop();
            AudioManager.Instance.sfxcSource.Stop();
            AudioManager.Instance.PlaySFX("QTE");
            QTE.GetComponent<QTESystem>().enabled = true;
        }
        else if (actualGuilt <= 0.0f)
        {
            AudioManager.Instance.sfxSource.Stop();
            AudioManager.Instance.sfxcSource.Stop();
            MenuPrincipalManager.cenaRetorno = SceneManager.GetActiveScene().name;
            SceneTransition.Instance.GoToScene("Game_Over");
        }
    }
}
