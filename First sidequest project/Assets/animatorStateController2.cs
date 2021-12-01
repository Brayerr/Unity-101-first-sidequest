using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorStateController2 : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey("w");
        bool isWalking = anim.GetBool("isWalking");
        bool sprintPress = Input.GetKey("left shift");
        bool jumpPress = Input.GetKey("space");

        if (!isWalking && forwardPress)
        {
            anim.SetBool("isWalking", true);            
        }

        if (isWalking && !forwardPress)
        {
            anim.SetBool("isWalking", false);
        }
    
        if(forwardPress && sprintPress)
        {
            anim.SetBool("isRunning", true);
        }

        if(!forwardPress || !sprintPress )
        {
            anim.SetBool("isRunning", false);
        }
        
        if(jumpPress)
        {
            anim.SetBool("isJumping", true);
        }

        if(!jumpPress)
        {
            anim.SetBool("isJumping", false);
        }
    }
}
