using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTarget;
    [SerializeField]
    private GameObject shield;

    private Vector3 rotate90;

    // Start is called before the first frame update
    void Start()
    {
        if (cameraTarget == null)
        {
            cameraTarget = GameObject.Find("CameraTarget").transform;
        }
        rotate90 = new Vector3(0f, 90f, 0f);
    }

    // Update is called once per frame
    //Rotate the ShieldSpawner with the camera
    void Update()
    {
        transform.rotation = cameraTarget.rotation;
    }

    public void SpawnShield()
    {
        Instantiate(shield, (transform.position + (transform.forward * 5) ), transform.rotation * Quaternion.AngleAxis(90, Vector3.up));
    }
}
