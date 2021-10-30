using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AITestController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float damage;
    //refactor to attack speed
    [SerializeField]
    private float timeBetweenAttacks = 0;
    [SerializeField]
    private float detectionRange = 0;
    [SerializeField]
    private float attackRange = 0;
    [SerializeField]
    private Vector3 wanderPoint;
    [SerializeField]
    private LayerMask groundMask, playerMask;
    [SerializeField]
    private bool playerInDetectionRange;
    [SerializeField]
    private bool playerInAttackRange;
    [SerializeField]



    private NavMeshAgent navMeshAgent;
    private Transform player;
    private bool wanderPointSet;
    private float wanderPointRange = 20f;
    private bool attacked;
    private Vector3 playerOffset;
    private float distanceToPlayerSquared;
    private ProjectileSpawner aiProjectileController;

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
        player = GameObject.Find("TempPlayer").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        state = State.Wandering;
        aiProjectileController = GetComponentInChildren<ProjectileSpawner>();
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

                playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, playerMask);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

                DetermineState();

                Wander();

                break;

            case State.Chasing:

                playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, playerMask);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

                DetermineState();

                Chasing();

                break;

            case State.Attacking:

                //Debug.Log("Attacking");

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
        if (playerInAttackRange) state = State.Attacking;
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
        //navMeshAgent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!attacked)
        {
            //Debug.Log("Attacked!");

            aiProjectileController.FireProjectile();

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
        navMeshAgent.speed = runSpeed;

        navMeshAgent.SetDestination(player.position);
    }

    private void Wander()
    {
        navMeshAgent.speed = walkSpeed;

        if (!wanderPointSet) SearchWanderPoint();

        if (wanderPointSet)
        {
            navMeshAgent.SetDestination(wanderPoint);

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

    void Die()
    {
        //animator.SetBool("isDead", true);
        state = State.Dead;
        navMeshAgent.SetDestination(transform.position);
        //fix enemy rotating after death and jitter usually after machine gun death
    }
}
