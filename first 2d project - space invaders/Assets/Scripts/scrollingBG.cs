using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBG : MonoBehaviour
{
    public float scrollSpeed = -1f;
    public float bgHeight = 10.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, scrollSpeed * Time.deltaTime);
        if (transform.position.y < -bgHeight)
            transform.position = new Vector3(0, bgHeight, 0);
    }
}
