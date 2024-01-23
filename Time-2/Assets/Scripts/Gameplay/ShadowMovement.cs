using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private Transform shadow;
    [SerializeField] private Transform frontPlayer;
    [SerializeField] private Transform shadowStart;
    [SerializeField] private Transform HalfWay;
    [SerializeField] private GameObject guiltObject;
    
    private int startMovement = 0;
    private float distance;
    private int guiltTime;
    [Range(0, 1)] [SerializeField] private float ShadowRetreatSpeed;

    


    private void Start()
    {
        distance = Vector2.Distance(shadow.position, frontPlayer.position);
    }

    private void Update()
    {
        if (startMovement == 1)
        {
            guiltTime = guiltObject.GetComponent<GuiltMeter>().halfGuilt;
            shadow.position = Vector2.MoveTowards(shadow.position, frontPlayer.position, Time.deltaTime * distance/guiltTime);
        }
        else if(startMovement == 2)
        {
            shadow.position = Vector2.Lerp(shadow.position, HalfWay.position, Time.deltaTime * ShadowRetreatSpeed);
        }
        else
        {
            shadow.position = Vector2.Lerp(shadow.position, shadowStart.position, Time.deltaTime * ShadowRetreatSpeed);
        }
    }

    public void RestartGuilt()
    {
        distance = Vector2.Distance(shadow.position, frontPlayer.position);
        guiltObject.GetComponent<GuiltMeter>().startGuilt(guiltTime);
    }

    public void moveShadow(){
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.PlaySFX("SombraChega");
        startMovement = 1;
    }

    public void HalfWayShadow()
    {
        startMovement = 2;
        AudioManager.Instance.PlaySFX("SombraSai");
        Invoke("RestartGuilt", 3);
    }
    public void retreatShadow()
    {
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.PlaySFX("SombraSai");
        startMovement = 0;
    }


}
