using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //add the type interaction information here and calculate the amount to send to the objects take damage function
    public void ApplyDamage(float damage)
    {
        //whatever damage calculations
        //this needs refactored into a health script...maybe health and damage should be the same script...
        gameObject.GetComponent<TestDummy>().takeDamage(damage);
    }
}
