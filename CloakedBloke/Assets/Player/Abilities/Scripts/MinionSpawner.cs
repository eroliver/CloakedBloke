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
    [SerializeField]
    private Transform cameraTarget;

    private Transform minionSpawnLocation;


    // Start is called before the first frame update
    void Start()
    {
        if (cameraTarget == null)
        {
            cameraTarget = GameObject.Find("CameraTarget").transform;
        }
        if (raycastOrigin == null)
        {
            raycastOrigin = cameraTarget;
        }
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
    public void SpawnMinion(GameObject minionPrefab)
    {
        RaycastHit locationHit;
        if (Physics.Raycast(raycastOrigin.transform.position, raycastOrigin.transform.forward, out locationHit, summonRange, targetableLayers))
        {
            GameObject minionInstance = Instantiate(minionPrefab, locationHit.point, transform.rotation);
            //add minion initialization code here, maybe targets nearby or where to face etc.
        }
    }
}
