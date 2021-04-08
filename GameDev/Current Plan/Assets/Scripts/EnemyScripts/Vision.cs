using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Enemyai enemyai;

    private void OnTriggerEnter2D(Collider2D i)
    {
        if(i.gameObject.GetComponent<PlayerMovement>())
        {
            enemyai.inView = true;
        }
    }
    private void OnTriggerExit2D(Collider2D i)
    {
        if(i.gameObject.GetComponent<PlayerMovement>())
        {
            enemyai.inView = false;
        }
    }
}
