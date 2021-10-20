using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class should be added to any porjectile based abilities, and the appropriate fields should be modified, i.e. the correct damage and hitEffect
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    private Rigidbody projectileRigidbody;

    [SerializeField]
    private GameObject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider target)
    {
        Debug.Log(target);
        //Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        target.GetComponent<Damage>().ApplyDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        projectileRigidbody.velocity = transform.forward * speed;
    }
}
