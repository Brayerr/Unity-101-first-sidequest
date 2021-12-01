using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    


 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        

        if (coin != null)
        {
            score = score + coin.value;
            Debug.Log("Collected!");
            Debug.Log("Add to score " + coin.value);
            coin.gameObject.SetActive(false);
        }
        Debug.Log("Current score is " + score);
    }
}
