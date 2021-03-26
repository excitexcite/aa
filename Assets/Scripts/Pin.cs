using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] private float speed = 20f; // pin move speed
    [SerializeField] Rigidbody2D rigidbody; // reference to RigidBody2D component
    private bool isPinned = false; // bool variable that tell if pin reach the rotator or not

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if pin does not reach the rotator
        if (!isPinned)
        {
            rigidbody.MovePosition(rigidbody.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionObj)
    {
        // if pin collides with the object with tag "Pin" (the other pin), we provides game over functionality
        if (collisionObj.tag == "Pin")
        {
            FindObjectOfType<Manager>().GameOver();
            // TODO GAMEOVER
        }
        // if pin collides with the object with tag "Rotator" (the Rotator)
        else if (collisionObj.tag == "Rotator")
        {
            isPinned = true; // stop pin's movement
            transform.SetParent(collisionObj.transform); // make pin part of the rotator
        }
    }

}
