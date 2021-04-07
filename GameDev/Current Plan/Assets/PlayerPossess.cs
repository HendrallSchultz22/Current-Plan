using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossess : MonoBehaviour
{
    bool InPossessRange = false;
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
    }

    void Possess()
    {
        if(InPossessRange)
        {
            //possess robot
            print("robot");
            //turn off player
            //add player movement script to robot
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
           if(collision.gameObject.tag == "Robot")
        {
            InPossessRange = false;
        }
    }
}
