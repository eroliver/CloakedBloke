using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTarget;
    [SerializeField]
    private GameObject shield;


    

    // Start is called before the first frame update
    void Start()
    {
        if (cameraTarget == null)
        {
            cameraTarget = GameObject.Find("CameraTarget").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnShield()
    {
        Instantiate(shield, transform.position, transform.rotation);
    }
}
