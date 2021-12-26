using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make the camera follow a target with a liitle delay
/// </summary>
public class CameraFollower : MonoBehaviour
{
    //the target of the camera
    public Transform target;
    //the delay value, the higher it will make the camera to follow faster
    //the lower the value it make the delay bigger
    public float smoothness = 5;
    //the offset of the camera from the target
    public Vector3 offset;
    //an anchor of the camera (if I  want to rotate the camera around a target I create an anchor object so I rotate it around it)
    private Transform _anchor;
    // Start is called before the first frame update
    void Start()
    {
        //create an empty anchor
        _anchor = new GameObject("anchor").transform;
        //creat the first offset
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move the camera to the position with the offset in a delayed function
        //lerp can achieve this kind of method
        transform.position = Vector3.Lerp(transform.position, target.position - offset, smoothness * Time.deltaTime);
    }

    //rotate the camera around the target with delta
    public void Rotate(float val)
    {
        //set the anchor position at the target
        _anchor.position = target.position;
        //make the anchor a parent of the camera
        transform.SetParent(_anchor);
        //rotate the anchor (that way the camera will rotate as well, according to the anchor rotation)
        _anchor.Rotate(Vector3.up * val);
        //update the offset (because the offset changed after rotation)
        offset = target.position - transform.position;
        //remove the camera as child of anchor
        transform.SetParent(null);
    }

    //make the camera focus on another target
    public void FocusOn(Transform t)
    {
        target = t;
    }
}
