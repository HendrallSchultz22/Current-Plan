using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireMove : MonoBehaviour
{
    [SerializeField]
    GameObject wireEnd;
    [SerializeField]
    GameObject wireStart;
    [SerializeField]
    float moveDistance = .5f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, wireEnd.transform.position, moveDistance);            
        }

        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, wireStart.transform.position, moveDistance);
            
        }

        

        
    }
}
