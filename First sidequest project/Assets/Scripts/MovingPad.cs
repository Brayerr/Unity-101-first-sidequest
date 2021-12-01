using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPad : MonoBehaviour
{
   
    public float speed = 0.01f;
    public Vector3 point1;
    public Vector3 point2;
    private Vector3 direction;
    public bool IsGoingToPoint2;

    // Start is called before the first frame update
    void Start()
    {
        direction = (point2 - point1).normalized;
        transform.position = point1;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = transform.position + direction * speed;
        if (IsGoingToPoint2)
        {
            if (Vector3.Distance(transform.position, point2) < 0.3f)
            {
                direction = direction * -1;
                IsGoingToPoint2 = false;

            }
        }
        else
        {
            if (Vector3.Distance(transform.position, point1) < 0.3f)
            {
                direction = direction * -1;
                IsGoingToPoint2 = true;
            }
        }
    }
}
