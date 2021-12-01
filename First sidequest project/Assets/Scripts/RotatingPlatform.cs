using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    public bool isRotating;
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateY == true)
        {
            isRotating = true;
            transform.Rotate(0, rotateSpeed, 0);
            if (rotateX == true)
            {
                transform.Rotate(rotateSpeed, rotateSpeed, 0);
                if (rotateZ == true)
                {
                    transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed);
                }
            }
        }
        else if (rotateX == true)
        {
            isRotating = true;
            transform.Rotate(rotateSpeed, 0, 0);
            if (rotateY == true)
            {
                transform.Rotate(rotateSpeed, rotateSpeed, 0);
                if (rotateZ == true)
                {
                    transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed);
                }
            }
        }
        else if (rotateZ == true)
        {
            isRotating = true;
            transform.Rotate(0, 0, rotateSpeed);
            if (rotateX == true)
            {
                transform.Rotate(rotateSpeed, 0, rotateSpeed);
                if (rotateY == true)
                {
                    transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed);
                }
            }
        }
        else
        {
            isRotating = false;
        }
    }
}
