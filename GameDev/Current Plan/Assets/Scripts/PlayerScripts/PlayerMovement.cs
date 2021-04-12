using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 3;
    Rigidbody2D rb;
    GroundCheck groundCheck;
    public bool IsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Robot"));
        foreach (GameObject robot in Enemies)
        {
            robot.gameObject.GetComponent<Enemyai>().PlayerLives = true;
        }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundCheck.isGrounded)
            {
                //jump            
                rb.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    private void OnDestroy()
    {
        IsAlive = false;
        foreach (GameObject robot in Enemies)
        {
            robot.gameObject.GetComponent<Enemyai>().PlayerLives = false;
        }
    }
}
