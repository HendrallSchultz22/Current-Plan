using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossess : MonoBehaviour
{
    [SerializeField] private bool InPossessRange;
    [SerializeField] private bool EngagePossess;
    [SerializeField] private GameObject possessionTarget;
    [SerializeField] private Quaternion originalRotation;
    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EngagePossess = true;
        }

        animator.SetBool("PossessEngaged", EngagePossess);
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnPossess();
        }
    }

    public void Possess()
    {
        if (gameObject.GetComponent<PlayerMovement>().IsAlive)
        {
            if (InPossessRange && possessionTarget.tag == "Robot")
            {
                //possess robot
                print("robot");
                //turn off player
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;


                gameObject.transform.parent = possessionTarget.transform;
                originalRotation = possessionTarget.transform.rotation;
                possessionTarget.transform.rotation = gameObject.transform.rotation;

                //add player movement script to robot
                possessionTarget.AddComponent<PlayerPossessEnemy>();
                possessionTarget.AddComponent<PlayerMovement>();
                possessionTarget.GetComponent<Enemyai>().enabled = false;
                InPossessRange = false;
                EngagePossess = false;
            }
            if (InPossessRange && possessionTarget.tag == "Wire")
            {
                // possess Wire
                print("wire");
                //*turn off player
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                possessionTarget.gameObject.transform.GetChild(0).gameObject.SetActive(true); // activates wire ball
                gameObject.transform.parent = possessionTarget.gameObject.transform.GetChild(0);
                InPossessRange = false;
                EngagePossess = false;
            }
        }
        
    }
    public void UnPossess()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        //gameObject.transform.rotation = zero ;
        if (possessionTarget.tag == "Robot")
        {
            Destroy(possessionTarget.GetComponent<PlayerPossessEnemy>());
            Destroy(possessionTarget.GetComponent<PlayerMovement>());
            possessionTarget.GetComponent<Enemyai>().enabled = true;
            possessionTarget.transform.rotation = originalRotation;
        }

        gameObject.transform.parent = null;
    }
    public void PossessObserver(string message)
    {
        if (message.Equals("PossesAnimationEnded"))
        {
            Possess();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Robot")
        {
            InPossessRange = true;
            possessionTarget = collision.gameObject;
            originalRotation = possessionTarget.transform.rotation;
        }
        if (collision.gameObject.tag == "Wire")
        {
            InPossessRange = true;
            possessionTarget = collision.gameObject; //gets the inWire object 
        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Robot")
    //    {
    //        InPossessRange = false;
    //        possessionTarget = null;
    //    }
    //    if (collision.gameObject.tag == "Wire")
    //    {
    //        InPossessRange = false;
    //        possessionTarget = null;
    //    }
    //}
}
