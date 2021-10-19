using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummy : MonoBehaviour
{
    public float health;

    private void Update()
    {
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
