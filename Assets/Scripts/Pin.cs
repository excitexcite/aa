using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] Rigidbody2D rigidbody;
    private bool isPinned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPinned)
        {
            rigidbody.MovePosition(rigidbody.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionObj)
    {
        if (collisionObj.tag == "Pin")
        {
            FindObjectOfType<Manager>().GameOver();
            // TODO GAMEOVER
        }
        else if (collisionObj.tag == "Rotator")
        {
            isPinned = true;
            transform.SetParent(collisionObj.transform);
        }
    }

}
