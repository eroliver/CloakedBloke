using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour
{
    public float health;

    private void Update()
    {
    }

    public void takeDamage(float amount)
    {
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
