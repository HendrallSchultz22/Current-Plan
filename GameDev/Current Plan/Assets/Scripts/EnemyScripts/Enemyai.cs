using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai : MonoBehaviour
{
    private Transform target;
    private PlayerMovement player;

    public bool PlayerLives;
    bool Pursuing = false;
    bool Idling = false;
    bool Attack = false;

    private float StartAttackCount = 4;
    private float EndAttackCount = 5;
    private float AttackDelay = 2;

    private bool LoopAttackInitiated;

    private bool IsAttacking;
    [SerializeField] private Transform Aim;
    private float distanceFromTarget;
    public bool inView;
    public Animator animator;
    Vector3 direction;
    private float walkSpeed = 2f;
    private int currentTarget;
    [SerializeField] private GameObject Projectile;
    private Transform[] waypoints = null;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<PlayerMovement>();
        Transform point1 = GameObject.Find("p1").transform;
        Transform point2 = GameObject.Find("p2").transform;
        Transform point3 = GameObject.Find("p3").transform;
        Transform point4 = GameObject.Find("p4").transform;
        Transform point5 = GameObject.Find("p5").transform;

        waypoints = new Transform[5] {
            point1,
            point2,
            point3,
            point4,
            point5
        };
    }

    private void Update()
    {
        if (Pursuing)
        {
            direction = target.position - transform.position;
            rotateRobot();
            if (PlayerLives)
            {
                direction = target.position - transform.position;
                rotateRobot();
            }      
        }
        if (!Idling)
        {
            transform.Translate(walkSpeed * direction * Time.deltaTime, Space.World);
        }
        if (Attack)
        {
            CalculateAttack();
        }
        if (!PlayerLives)
        {
            target = null;
            player = null;
        }
    }
    private void FixedUpdate()
    {
        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("DistanceFromWaypoint", distanceFromTarget);
        animator.SetBool("TargetInSight", inView);
    }
    public void SetNextPoint()
    {
        int nextPoint = 1;


        nextPoint = Random.Range(0, waypoints.Length - 1);
      
        currentTarget = nextPoint;
        direction = waypoints[currentTarget].position - transform.position;
        rotateRobot();
    }
    public void Pursue()
    {
        direction = target.position - transform.position;
        rotateRobot();
    }
    public void StopPursuit()
    {
        Pursuing = false;
    }
    private void rotateRobot()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        direction = direction.normalized;
    }
    public void StartPursuit()
    {
        Pursuing = true;
    }


    public void ToggleIdling()
    {
        Idling = !Idling;
    }
    public void HaltAndFire()
    {

        Idling = true;
        Attack = true;
    }
    public void EndFiring()
    {

        Idling = false;
        Attack = false;
    }
    void CalculateAttack()
    {
        if (!LoopAttackInitiated)
        {
            LoopAttackInitiated = true;
            StartAttackCount = Time.time + (1 / AttackDelay);
            EndAttackCount = Time.time + (1 / EndAttackCount);
            SetAttack();
        }

        if (LoopAttackInitiated)
        {

            if (Time.time >= StartAttackCount)
            {
                LoopAttackInitiated = false;
            }

            else if (Time.time >= EndAttackCount && IsAttacking == true)
            {
                StopAttack();
            }
        }
    }
    public void SetAttack()
    {
        Instantiate(Projectile, Aim.position, Aim.rotation);
        IsAttacking = true;
    }
    public void StopAttack()
    {
        IsAttacking = false;
    }
}
