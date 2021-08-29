using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.Animations;


public class EnemyUnit : MonoBehaviour
{
    private NavMeshAgent agent;
    public EnemyData data;
    private Vector3 startPos;
    private Vector3 targetPos;
    public float speed = 1;
    public float roamRadius = 5;
    //public float debugDistance;
    public Vector2 IdleRange;
    [SerializeField]
    private bool idling = false;
    public Animator animator;

    public float agroDistance = 3;
    public float agroSpeed = 2;
    private Transform player;
    public bool agrv = false;
    private Coroutine chaseRoutine;
    private bool overrideVelocity = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Roam();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agrv = false;
    }

    private void CalculateDirection()
    {
        //Vector3 dir = (targetPos - startPos).normalized;
    }

    private void Roam()
    {
        Vector3 target = startPos + Random.insideUnitSphere * roamRadius;
        targetPos = new Vector3(target.x, startPos.y, target.z);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = (targetPos);
    }


    private void Update()
    {
        animator.SetFloat("LRVelocity", agent.velocity.x);
        animator.SetFloat("FBVelocity", agent.velocity.z);


        if (idling)
        {
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Moving", true);
        }

        if (agrv)
        {
            animator.SetBool("Agro", true);
        }
        else
        {
            animator.SetBool("Agro", false);
        }

        //debugDistance = agent.remainingDistance;

        if (agent.remainingDistance < 2 && !idling)
        {
            //Debug.Log("indistance");
            StartCoroutine(Idle(Random.Range(IdleRange.x, IdleRange.y)));
        }

        if (Vector3.Distance(gameObject.transform.position, player.position) < agroDistance)
        {
            if (!agrv) Agro(true, player);
        }
        else
        {
            if (agrv) Agro(false, player);
        }
    }

    private IEnumerator Idle(float waitTime)
    {
        idling = true;
        //Debug.Log("Waiting " + waitTime + " seconds");
        float oriVal = animator.GetFloat("IdleVal");
        float targetVal = Random.Range(0f, 1f);
        //Debug.Log("rand" + targetVal);
        animator.SetFloat("IdleVal", targetVal);

        yield return new WaitForSeconds(waitTime);
        idling = false;
        animator.SetFloat("IdleVal", oriVal);
        Roam();

    }

    public void Agro(bool agro, Transform agroTarget)
    {
        if (agroTarget == null) return;
        if (agro)
        {
            agent.speed = agroSpeed;
            agrv = true;
            chaseRoutine = StartCoroutine(Chase(agroTarget));
            animator.SetFloat("FBVelocity", 1.5f);
        }
        else
        {
            //Debug.Log("hey");
            agent.speed = speed;
            Roam();
            agrv = false;
            StopCoroutine(chaseRoutine);
        }
    }

    private IEnumerator Chase(Transform target)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            Debug.Log("chasin");
            agent.destination = (target.position);
        }
    }
}
