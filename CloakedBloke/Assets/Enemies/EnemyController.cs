using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float health = 20f;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private LayerMask groundMask, playerMask;
    //refactor to attack speed
    [SerializeField]
    private float timeBetweenAttacks = 0;
    [SerializeField]
    private float detectionRange = 0;
    [SerializeField]
    private float attackRange = 0;
    [SerializeField]
    private float attackDamage;

    private Transform player;
    [SerializeField]
    private Vector3 wanderPoint;
    private bool wanderPointSet;
    private float wanderPointRange = 20f;
    private bool attacked;
    private bool playerInDetectionRange;
    private bool playerInAttackRange;
    private Vector3 playerOffset;
    private float distanceToPlayerSquared;

    [SerializeField]
    private Transform testLocation;

    private void Awake()
    {
        player = UnityEngine.GameObject.Find("TempPlayer").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    void TestMove()
    {
        if (testLocation == null)
        {
            Debug.LogError("The navmesh component is not attached to " + gameObject.name);
        }
        else
        {
            TestSetDestination();
        }
    }

    private void TestSetDestination()
    {
        if (testLocation != null)
        {
            Vector3 targetVector = testLocation.transform.position;
            agent.SetDestination(targetVector);
        }
    }

    private enum State
    {
        Idle,
        Wandering,
        Chasing,
        Attacking,
        Dead
    }
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        if (attackDamage == 0)
        {
            attackDamage = 30;
        }
        state = State.Wandering;
    }

    // Update is called once per frame
    void Update()
    {

        playerOffset = player.position - transform.position;
        distanceToPlayerSquared = playerOffset.sqrMagnitude;

        CheckForPlayerInRange();


        switch (state)
        {

            case State.Wandering:

                //playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, playerMask);
                //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

                DetermineState();

                //Wander();

                break;

            case State.Chasing:

                //playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, playerMask);
                //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

                DetermineState();

                //Chasing();

                break;

            case State.Attacking:

                Debug.Log("Attacking");

                DetermineState();

                Attack();

                break;

            case State.Dead:

                break;
        }
    }

    private void DetermineState()
    {
        if (!playerInDetectionRange && !playerInAttackRange) state = State.Wandering;
        if (playerInDetectionRange && !playerInAttackRange) state = State.Chasing;
        if (playerInDetectionRange && playerInAttackRange) state = State.Attacking;
    }

    //refactor to take in range argument
    private void CheckForPlayerInRange()
    {
        if (distanceToPlayerSquared <= detectionRange * detectionRange)
        {
            playerInDetectionRange = true;
        }
        else
        {
            playerInDetectionRange = false;
        }
        if (distanceToPlayerSquared <= attackRange * attackRange)
        {
            playerInAttackRange = true;
        }
        else
        {
            playerInAttackRange = false;
        }
    }

    private void Attack()
    {
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!attacked)
        {
            Debug.Log("Attacked!");

            attacked = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

    private void Wander()
    {
        if (!wanderPointSet) SearchWanderPoint();

        if (wanderPointSet)
        {
            agent.Warp(wanderPoint);

            Vector3 distanceToWanderPoint = transform.position - wanderPoint;

            if (distanceToWanderPoint.magnitude < 3f)
            {
                wanderPointSet = false;
            }
        }
    }

    private void SearchWanderPoint()
    {
        float randomZ = Random.Range(-wanderPointRange, wanderPointRange);
        float randomX = Random.Range(-wanderPointRange, wanderPointRange);


        Vector3 groundCheck = new Vector3(transform.position.x + randomX, transform.position.y + 2f, transform.position.z + randomZ);
        //get hit output from groundcheck to pass into wanderPoint
        if (Physics.Raycast(groundCheck, -transform.up, 8f, groundMask))
        {
            wanderPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            wanderPointSet = true;
        }
        else
        {
            wanderPointSet = false;
        }

    }

    private void Idle()
    {
        Debug.Log("Idling");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        state = State.Dead;
        agent.SetDestination(transform.position);
        //fix enemy rotating after death and jitter usually after machine gun death
    }

}
