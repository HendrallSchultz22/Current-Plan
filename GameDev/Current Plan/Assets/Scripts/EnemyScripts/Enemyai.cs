using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai : MonoBehaviour
{
    private Transform target;

    bool Pursuing = false;
    bool Idling = false;
    private float distanceFromTarget;
    public bool inView;
    public Animator animator;
    Vector3 direction;
    private float walkSpeed = 2f;
    private int currentTarget;
    private Transform[] waypoints = null;

    private void Awake()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;


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
        }

        if (!Idling)
        {
            transform.Translate(walkSpeed * direction * Time.deltaTime, Space.World);
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

        while (nextPoint == currentTarget)
        {
            nextPoint = Random.Range(0, waypoints.Length - 1);
        }
        

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

    }

    public void Attack()
    {

    }

}
