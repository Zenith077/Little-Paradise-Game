using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float moveSpeed;
    public float stopDistance;
    float speed;

    Transform target;
    GameObject player;

    NavMeshAgent agent;

    float turnSmoothVelocity;
    Vector3 targetDir;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    public void Movement()
    {
        // rb.velocity = agent.velocity;

        
       // agent.SetDestination(target.position);
    }

    void Rotate()
    {
    }


    /*
    GameObject player;
    Rigidbody rb;


    NavMeshAgent agent;
    public Transform target;
    Vector3 targetDir;
    Vector3 distanceToTarget;
    NavMeshPath path;
    public float pathUpdateTime;
    float pathUpdateElapsed;

    float turnSmoothVelocity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;

        #region Debug Error
        if (player == null)
            Debug.LogError(player + "not found!");
        if (agent == null)
            Debug.LogError(agent + "not found!");
        #endregion



        path = new NavMeshPath();
        pathUpdateElapsed = 0.0f;

        //initial path
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
    }

    public void Movement()
    {
        //You can turn off automatic movement and get an intended velocity from the agent,
        //which when added to transform.position, moves it identically.

        CalculatePath();


        //get direction towards target
        targetDir = (transform.position - path.corners[1]).normalized;
        targetDir = -targetDir; //if this works im a genius

        //Rotate towards Target
        Rotation();

        // deploy movement
        agent.velocity = targetDir * moveSpeed;

    }

    void Rotation()
    { 
    }

    void CalculatePath()
    {
        // Update the way to the goal every second.
        pathUpdateElapsed += Time.deltaTime;
        if (pathUpdateElapsed > pathUpdateTime)
        {
            pathUpdateElapsed -= pathUpdateTime;
            // Calculate path
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }

        // draw line towards target for debugging
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }*/
}
