using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for common functionality shared by all abilities like cool downs. 
public abstract class Ability : MonoBehaviour
{
    [Tooltip("Cool down the player will have to wait before using this ability again.")]
    [SerializeField]
    private float cooldown;
    [Tooltip("Which type of controller should this ability use?")]
    [SerializeField]
    private Controllers controller;


    private enum Controllers
    {
        Projectile,
        Minion,
        Shield
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetController()
    {
        return (int)controller;
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
