using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AITestController : MonoBehaviour
{
    [SerializeField]
    private Transform testLocation;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TestMove();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
