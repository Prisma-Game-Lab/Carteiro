using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    public Transform shadow;
    public Transform frontPlayer;
    public Transform ShadowStart;

    [Range(0, 1)] public float ShadowSpeed;
    [Range(0, 1)] public float ShadowRetreatSpeed;

    private bool startMovement = false;

    private void FixedUpdate()
    {
        if(startMovement)
        {
            shadow.position = Vector2.MoveTowards(shadow.position, frontPlayer.position, Time.deltaTime * ShadowSpeed);
        }
        else
        {
            shadow.position = Vector2.Lerp(shadow.position, ShadowStart.position, Time.deltaTime * ShadowRetreatSpeed);
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
