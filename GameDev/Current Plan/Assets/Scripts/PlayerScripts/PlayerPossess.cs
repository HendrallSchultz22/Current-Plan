using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossess : MonoBehaviour
{
    bool InPossessRange = false;
    GameObject possessionTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * if(near possessable object & button is pressed)
         * {
         *  Possess()
         * }
         * */

        if (Input.GetKeyDown(KeyCode.P))
        {
            Possess();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<PlayerMovement>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            Destroy(possessionTarget.GetComponent<PlayerMovement>());
            gameObject.transform.parent = null;
                        
        }
    }

    void Possess()
    {
        if(InPossessRange)
        {
            //possess robot
            print("robot");
            //turn off player
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;            
            gameObject.transform.parent = possessionTarget.transform;
            //add player movement script to robot
            possessionTarget.AddComponent<PlayerMovement>();
        }

        if (/*wire*/true)
        {
            // possess Wire
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Robot")
        {
            InPossessRange = true;
            possessionTarget = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
           if(collision.gameObject.tag == "Robot")
        {
            InPossessRange = false;
            //possessionTarget = null;
        }
    }
}
