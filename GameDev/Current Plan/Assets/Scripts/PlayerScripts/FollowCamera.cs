using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    private PlayerMovement controller;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = player.gameObject.GetComponent<PlayerMovement>();
    }
    void LateUpdate()
    {
        if (controller.IsAlive)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }

    }
}
