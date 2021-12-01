using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingScript : MonoBehaviour
{
    public float incrementSpeed = 0.03f;
    public bool isGrowing;
    public Vector3 location;
    public Vector3 minScale;
    public Vector3 maxScale;
    private Vector3 grow;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = location;
        transform.localScale = minScale;
        transform.localScale = maxScale;
        grow = (maxScale - minScale).normalized;
        isGrowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale + grow * incrementSpeed;
        if (isGrowing)
        {
            if (Vector3.Distance(transform.localScale , maxScale) < 0.3f)
            {
                incrementSpeed = incrementSpeed * -1;
                isGrowing = false;
            }
        }
        else 
        {
        if (Vector3.Distance(transform.localScale , minScale) <0.3f)
            {
                incrementSpeed = incrementSpeed * -1;
                isGrowing = true;
            }
        } 
    }
    }
