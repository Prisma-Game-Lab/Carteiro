using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public Transform[] parts;
    public Vector3 nextPartPosition;
    public GameObject player;
    public float partDrawDistance;
    public float partDeleteDistance;

    private int counter = 0;

    void Start()
    {
        LoadParts();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            counter++;
        }

        RemoveParts();
        LoadParts();
    }

    void LoadParts()
    {
        while((nextPartPosition - player.transform.position).x < partDrawDistance)
        {
            Transform part;
            Transform newPart;
            if(counter == 0)
            {
                part = parts[counter];
                newPart = Instantiate(part, nextPartPosition - part.Find("StartPoint").position, part.rotation, transform);
            }
            else if(counter == 1)
            {
                part = parts[counter];
                newPart = Instantiate(part, nextPartPosition - part.Find("StartPoint").position, part.rotation, transform);
                counter--;
            }
            else
            {
                part = parts[counter];
                newPart = Instantiate(part, nextPartPosition - part.Find("StartPoint").position, part.rotation, transform);
                counter -= 2;
            }

            nextPartPosition = newPart.Find("EndPoint").position;
        }
    }

    void RemoveParts()
    {
        if(transform.childCount > 0)
        {
            Transform part = transform.GetChild(0);
            Vector3 diff = player.transform.position - part.position;

            if(diff.x > partDeleteDistance)
            {
                Destroy(part.gameObject);
            }
        }
    }
}
