using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    Damageables damageable;

    //use this enum to differentiate between the types of objects that have hp.
    //Can give unique behavior based on the object with health.
    private enum Damageables
    {
        enemy,
        player,
        destructable,
        shield
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //add the type interaction information here and calculate the amount to send to the objects take damage function
    public void TakeDamage(float amount)
    {//whatever damage calculations
     //this needs refactored into a health script...maybe health and damage should be the same script...
        health = health - amount;

        switch (damageable)
        {
            case Damageables.player:
                if (health <= 0)
                {
                    SceneManager.LoadScene("Hub");
                }
                else
                {
                    Debug.Log(health);
                }
                break;
            case Damageables.enemy:
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log(health);
                }
                break;
            case Damageables.destructable:
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log(health);
                }
                break;
            case Damageables.shield:
                if (health <= 0)
                {
                    GetComponent<Shield>().Break();
                }
                else
                {
                    Debug.Log(health);
                }
                break;
            default:
                break;
        }
    }

    private void Die()
    {

    }

    public void ApplyDoT(float amount, int duration)
    {
        StartCoroutine(Example());
    }

    public IEnumerator DoT(float amount, int duration)
    {
        int appliedDuration = 0;
        while (duration > 0)
        {
            yield return new WaitForSeconds(1);
            duration--;
            TakeDamage(amount);
            Debug.Log("DoT damage tic");

            //Debug.Log("waited");
            TakeDamage(amount);
            Debug.Log("second tic");
        }
        //enable dot effect, probably need passed in the function if we are using more than burning. maybe strat with just buning.
    }

        IEnumerator Example()
        {
            print(Time.time);
            yield return new WaitForSecondsRealtime(5);
            print(Time.time);
        }
}
