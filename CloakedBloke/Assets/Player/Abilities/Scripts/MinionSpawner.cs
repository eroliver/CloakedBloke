using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject minion;
    [SerializeField]
    private LayerMask targetableLayers;
    [SerializeField]
    private Transform raycastOrigin;
    [SerializeField]
    private float summonRange;

    private Transform minionSpawnLocation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMinion()
    {
        RaycastHit locationHit;
        if (Physics.Raycast(raycastOrigin.transform.position, raycastOrigin.transform.forward, out locationHit, summonRange, targetableLayers))
        {
            GameObject minionInstance = Instantiate(minion, transform.position, transform.rotation);
            //add minion initialization code here, maybe targets nearby or where to face etc.
        }
    }
}
