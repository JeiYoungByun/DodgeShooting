using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start()
    {   
        //get bullet's rigidbody component reference
        bulletRigidbody = GetComponent<Rigidbody>();

        //set z axis 8f speed
        bulletRigidbody.velocity = transform.forward * speed;

        //after 3 seconds object destroy
        Destroy(gameObject, 3f);
    }

    //trigger method
    void OnTriggerEnter(Collider other)
    {
        //if collided object have player tag
        if (other.tag == "Player") 
        {
            //get PlayerController component from other
            PlayerController playerController = other.GetComponent<PlayerController>(); 

            //success getting playercontroller component
            if(playerController != null)
            {
                //other's playercontroller execute die method
                playerController.Die();
            }
        }
    }
}
