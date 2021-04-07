using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    int speed = 5;
    [SerializeField]
    int jumpForce = 5;
    Rigidbody2D rigidbody2D;
    GroundCheck groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //move left
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //move right
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            if (groundCheck.isGrounded)
            {
                //jump            
                rigidbody2D.AddForce((Vector2.up * jumpForce * Time.deltaTime), ForceMode2D.Impulse);
            }
        }

    }
}
