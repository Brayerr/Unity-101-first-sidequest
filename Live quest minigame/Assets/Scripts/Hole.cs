using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The end hole, to target of the game
/// </summary>
public class Hole : MonoBehaviour
{
    //an special Unity event that can be used in the Unity Engine
    public UnityEvent CompletedCourse;
    private void OnTriggerEnter(Collider other)
    {
        //check if it is a ball
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Reached end hole!");
            //zero velocity
            other.attachedRigidbody.velocity = Vector3.zero;
            //zero rotation
            other.attachedRigidbody.angularVelocity = Vector3.zero;
            //invoke the event
            CompletedCourse.Invoke();
        }
    }
}
