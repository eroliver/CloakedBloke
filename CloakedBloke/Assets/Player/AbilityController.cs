using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle all input from the player that is related to abilites to avoid adding complexity to the movement scripts
public class AbilityController : MonoBehaviour
{
    [SerializeField]
    private KeyCode ability1Key;
    [SerializeField]
    private GameObject ability1;
    [SerializeField]
    private KeyCode ability2Key;
    [SerializeField]
    private GameObject ability2;
    [SerializeField]
    private KeyCode ability3Key;
    [SerializeField]
    private GameObject ability3;
    [SerializeField]
    private KeyCode ability4Key;
    [SerializeField]
    private GameObject ability4;
    [SerializeField]
    private KeyCode ability5Key;
    [SerializeField]
    private GameObject ability5;
    [SerializeField]
    private KeyCode ability6Key = KeyCode.LeftShift;
    //[SerializeField]
    //private GameObject ability6;

    //Types of of spawners
    [SerializeField]
    private GameObject abilitySpawner;
    [SerializeField]
    private GameObject shieldSpawner;
    [SerializeField]
    private GameObject minionSpawner;
    //ability controllers
    private GameObject ability1Controller;
    private GameObject ability2Controller;
    private GameObject ability3Controller;
    private GameObject ability4Controller;
    private GameObject ability5Controller;

    //variables for movement abilities, speed might need to become distance...testing needed.
    [SerializeField]
    private int dashSpeed;

    private Rigidbody playerRigidbody;
    private bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponentInParent<Rigidbody>();

        UpdateAbilityControls();
    }

    // Update is called once per frame
    void Update()
    {
        //lock the cursor in the game so mouse isn't leaving while play testing
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //refactor this out to detect ability key pressed function, which could hold global cd
        if (Input.GetKeyDown(ability1Key))
        {
            ability1Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability1);
        }

        if (Input.GetKeyDown(ability2Key))
        {
            ability2Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability2);

        }
        if (Input.GetKeyDown(ability3Key))
        {
            ability3Controller.GetComponent<ShieldSpawner>().SpawnShield();

        }
        if (Input.GetKeyDown(ability4Key))
        {
            ability4Controller.GetComponent<MinionSpawner>().SpawnMinion(ability4);

        }

        if (Input.GetKeyDown(ability6Key))
        {
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dash();
        }
    }

    private void Dash()
    {
        playerRigidbody.AddForce(transform.forward * dashSpeed, ForceMode.VelocityChange);

        isDashing = false;
    }

    private void UpdateAbilityControls()
    {
        if (ability1 != null)
        {
            if (ability1.GetComponent<Projectile>())
            {
                ability1Controller = Instantiate(abilitySpawner, transform, false);
            }
            else if (ability1.GetComponent<Minion>())
            {
                ability1Controller = Instantiate(abilitySpawner, transform, false);
            }
        }
        if (ability2 != null)
        {
            if (ability2.GetComponent<Projectile>())
            {
                ability2Controller = Instantiate(abilitySpawner, transform, false);
            }
        }
        if (ability3 != null)
        {
            if (ability3.GetComponent<Shield>())
            {
                ability3Controller = Instantiate(shieldSpawner, transform, false);
            }
        }
        if (ability4 != null)
        {
            if (ability4.GetComponent<Minion>())
            {
                ability4Controller = Instantiate(minionSpawner, transform, false);
            }
        }
    }


}
