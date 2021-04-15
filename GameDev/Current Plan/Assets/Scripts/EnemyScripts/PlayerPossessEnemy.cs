using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossessEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform AimLeft;
    [SerializeField] private Transform AimRight;
    public bool IsLeft;
    public bool IsRight;
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Interact();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Shoot();
        }
    }
    void Interact()
    {

    }
    void Shoot()
    {
        if (IsLeft)
        {
            Instantiate(Projectile, AimLeft.position, AimLeft.rotation);
        }
        if (IsRight)
        {
            Instantiate(Projectile, AimRight.position, AimRight.rotation);
        }
    }
}
