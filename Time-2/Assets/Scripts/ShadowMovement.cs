using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private Transform shadow;
    [SerializeField] private Transform frontPlayer;
    [SerializeField] private Transform shadowStart;
    [SerializeField] private GameObject guiltObject;
    
    private bool startMovement = false;
    private float distance;
    private int guiltTime;
    [Range(0, 1)] [SerializeField] private float ShadowRetreatSpeed;

    


    private void Start()
    {
        distance = Vector2.Distance(shadow.position, frontPlayer.position);
    }

    private void Update()
    {
        if (startMovement)
        {
            guiltTime = guiltObject.GetComponent<GuiltMeter>().halfGuilt;
            shadow.position = Vector2.MoveTowards(shadow.position, frontPlayer.position, Time.deltaTime * distance/guiltTime);
        }
        else
        {
            shadow.position = Vector2.Lerp(shadow.position, shadowStart.position, Time.deltaTime * ShadowRetreatSpeed);
        }
    }

    public void moveShadow(){
        startMovement = true;
    }

    public void retreatShadow()
    {
        startMovement = false;
    }


}
