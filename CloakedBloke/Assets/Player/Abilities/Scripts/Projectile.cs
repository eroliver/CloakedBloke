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
    [SerializeField]
    private float amount;
    [SerializeField]
    private float duration;
    [SerializeField]
    private GameObject hitEffect;

    private Rigidbody projectileRigidbody;
    private Collider projectileCollider;

    // Start is called before the first frame update
    void Start()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
        projectileCollider = GetComponent<Collider>();
        projectileRigidbody.velocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
    }

    //for non-physics projectiles: fireball
    private void OnTriggerEnter(Collider target)
    {
        //Debug.Log(target);
        Instantiate(hitEffect, transform.position, transform.rotation); 
        Destroy(gameObject);
        var targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            target.GetComponent<Health>().TakeDamage(damage);
        }
    }
    //for physics based projectiles: ice spike
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        var targetHealth = collision.collider.GetComponent<Health>();
        var targetEffect = collision.collider.GetComponent<Effect>();

        if (targetHealth != null)
        {
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
        if (targetEffect != null)
        {
            collision.collider.GetComponent<Effect>().Slow(amount, duration);
        }
        Destroy(gameObject);
    }

}
