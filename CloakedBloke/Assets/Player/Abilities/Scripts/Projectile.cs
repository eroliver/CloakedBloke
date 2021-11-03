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
    private float slowAmount;
    [SerializeField]
    private float slowDuration;
    [SerializeField]
    private float DamageOverTime;
    [SerializeField]
    private int DoTDuration;

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

    //TODO refactor projectile to check for which values it has before checking for target components
    //No reason to check for effect script if you aren't applying one. Assuming that's faster.
    //for non-physics projectiles: fireball
    private void OnTriggerEnter(Collider target)
    {
        //Debug.Log(target);
        Instantiate(hitEffect, transform.position, transform.rotation); 
        Destroy(gameObject);
        var targetHealth = target.GetComponent<Health>();
        var targetEffect = target.GetComponent<Effect>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
            targetHealth.ApplyDoT(DamageOverTime, DoTDuration);
        }
        if (targetEffect != null)
        {
            target.GetComponent<Effect>().Slow(slowAmount, slowDuration);

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
            targetHealth.ApplyDoT(DamageOverTime, DoTDuration);

        }
        if (targetEffect != null)
        {
            collision.collider.GetComponent<Effect>().Slow(slowAmount, slowDuration);
        }
        Destroy(gameObject);
    }

}
