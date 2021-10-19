using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject hitEffect;

    private void OnTriggerEnter(Collider target)
    {
        Debug.Log(target);
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            GameObject fireball = Instantiate(projectile, transform.position, transform.rotation);

        }
    }
}
