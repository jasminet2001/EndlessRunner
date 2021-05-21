using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Batman playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<Batman>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //the name of the player is running
        if (collision.gameObject.name == "Running")
        {
            //kill the player
            playerMovement.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
