using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform egg;
    public NavMeshAgent agent;
    public GameObject[] waypoints;

    private Vector3 targetPosition;
    private float distanceToEgg;

    private bool holdingEgg = false;
    private bool canHold = false;
    private bool ignoreEgg = false;

    [SerializeField] private float speed = 6f;
    public float chaseRange = 0f;
    public GameObject player;

    enum EnemyState {
        Waiting,
        Chasing,
        Bringing
    }

    EnemyState currentState;

    void Start()
    {
        currentState = EnemyState.Waiting;
        agent.updateUpAxis = false;
        // waypoints = GameObject.FindGameObjectsWithTag("Enemy Waypoint");

        if (egg == null)
        {
            egg = GameObject.FindWithTag("Egg").transform;
        }

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        StartCoroutine(SetTargetPosition());
    }

    void Update()
    {
        StateCheck();
        distanceToEgg = Vector3.Distance(transform.position, egg.position);

        if (ignoreEgg && distanceToEgg > chaseRange * 3f) // Reset when far enough
        {
            ignoreEgg = false;
        }

        if (distanceToEgg <= chaseRange && !holdingEgg)
        {
            currentState = EnemyState.Chasing;
        }
        else if (!holdingEgg)
        {
            currentState = EnemyState.Waiting;
        }

        if (holdingEgg)
        {
            egg.transform.position = transform.position + new Vector3 (0, 2, 0);

            if (transform.position.x == targetPosition.x && transform.position.z == targetPosition.z && currentState == EnemyState.Bringing)
            {
                currentState = EnemyState.Waiting;
            }
        }

        Debug.Log(targetPosition + " " + currentState + " " + ignoreEgg);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Egg") && canHold)
        {
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            Rigidbody egg_RigidBody = collision.gameObject.GetComponent<Rigidbody>();
            // if egg usegravity == false, call player release egg
            if(!egg_RigidBody.useGravity) { playerScript.ReleaseEgg(); }
            currentState = EnemyState.Bringing;
        }
    }

    private IEnumerator SetTargetPosition()
    {
        yield return new WaitUntil (() => agent.velocity == new Vector3(0, 0, 0));

        if (currentState == EnemyState.Waiting)
        {
            targetPosition = waypoints[0].transform.position;
        }
        else if (currentState == EnemyState.Chasing)
        {
            targetPosition = egg.transform.position;
        }
        else if (currentState == EnemyState.Bringing)
        {
            targetPosition = waypoints[1].transform.position;
        }

        agent.SetDestination(targetPosition);
        StartCoroutine(SetTargetPosition());
    }

    private void RotateTowardsTarget(Vector3 rotatePosition)
    {
        // Handle Rotation
        Quaternion lookRotation = Quaternion.LookRotation(rotatePosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void StateCheck()
    {
        if (currentState == EnemyState.Waiting)
        {
            canHold = false;
            
            if (holdingEgg)
            {
                holdingEgg = false;
                ReleaseEgg();
            }

            ignoreEgg = true;
        }
        else if (currentState == EnemyState.Chasing)
        {
            canHold = true;
        }
        else if (currentState == EnemyState.Bringing)
        {
            holdingEgg = true;
        }
    }

    private void ReleaseEgg()
    {
        if (egg != null)
        {
            // Detach the egg from the enemy
            egg.SetParent(null);

            // Optionally, reset its position or add physics behavior
            Rigidbody eggRb = egg.GetComponent<Rigidbody>();
            if (eggRb != null)
            {
                egg.transform.position = transform.position;
                eggRb.isKinematic = false; // Allow the egg to fall naturally
            }
        }
    }
}
