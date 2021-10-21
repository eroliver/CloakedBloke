using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

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
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(health);
        }
    }
}
