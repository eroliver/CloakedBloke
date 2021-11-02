using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField]
    private AITestController enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<AITestController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slow(float amount, float duration)
    {
        StartCoroutine(enemyMovement.Slow(amount, duration));
        Debug.Log("slowed effect");
    }
}
