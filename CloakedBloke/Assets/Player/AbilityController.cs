using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handle all input from the player that is related to abilites to avoid adding complexity to the movement scripts
public class AbilityController : MonoBehaviour
{
    //make this a dictionary so you can define the controller that each ability uses. 
    //then the value can be the controller.
    
    [Header("Ability1")]
    [SerializeField]
    private KeyCode ability1Key;
    [SerializeField]
    private GameObject ability1;
    [SerializeField]
    private Image ability1Image;

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
    private KeyCode dashKey = KeyCode.LeftShift;
    //[SerializeField]
    //private GameObject ability6;

    //Types of of spawners
    [SerializeField]
    private GameObject projectileSpawner;
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

    //enum of the controllers used to allow certain controllers on certain keys
    private enum Controllers
    {
        Projectile,
        Minion,
        Shield
    }

    private Controllers controller1;
    private Controllers controller2;
    private Controllers controller3;
    private Controllers controller4;
    private Controllers controller5;

    //cooldown for each ability
    private float ability1Cooldown = 5f;
    private float ability2Cooldown;
    private float ability3Cooldown;
    private float ability4Cooldown;
    private float ability5Cooldown;

    private bool ability1OnCooldown = false;
    private bool ability2OnCooldown;
    private bool ability3OnCooldown;
    private bool ability4OnCooldown;
    private bool ability5OnCooldown;

    //variables for movement abilities, speed might need to become distance...testing needed.
    [SerializeField]
    private int dashSpeed;

    private Rigidbody playerRigidbody;
    private bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponentInParent<Rigidbody>();

        ability1Image.fillAmount = 0;
        

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

        ActivateAbility1();

        //refactor this out to detect ability key pressed function, which could hold global cd
        //if (Input.GetKeyDown(ability1Key))
        //{
        //    switch (controller1)
        //    {
        //        case Controllers.Shield:
        //            ability1Controller.GetComponent<ShieldSpawner>().SpawnShield();
        //            break;
        //        case Controllers.Minion:
        //            ability1Controller.GetComponent<MinionSpawner>().SpawnMinion(ability1);
        //            break;
        //        case Controllers.Projectile:
        //            ability1Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability1);
        //            break;
        //        default:
        //            ability1Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability1);
        //            break;
        //    }
        //}

        if (Input.GetKeyDown(ability2Key))
        {
            switch (controller2)
            {
                case Controllers.Shield:
                    ability2Controller.GetComponent<ShieldSpawner>().SpawnShield();
                    break;
                case Controllers.Minion:
                    ability2Controller.GetComponent<MinionSpawner>().SpawnMinion(ability2);
                    break;
                case Controllers.Projectile:
                    ability2Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability2);
                    break;
                default:
                    ability2Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability2);
                    break;
            }
        }
        if (Input.GetKeyDown(ability3Key))
        {
            switch (controller3)
            {
                case Controllers.Shield:
                    ability3Controller.GetComponent<ShieldSpawner>().SpawnShield();
                    break;
                case Controllers.Minion:
                    ability3Controller.GetComponent<MinionSpawner>().SpawnMinion(ability3);
                    break;
                case Controllers.Projectile:
                    ability3Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability3);
                    break;
                default:
                    ability3Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability3);
                    break;
            }
        }
        if (Input.GetKeyDown(ability4Key))
        {
            switch (controller4)
            {
                case Controllers.Shield:
                    ability4Controller.GetComponent<ShieldSpawner>().SpawnShield();
                    break;
                case Controllers.Minion:
                    ability4Controller.GetComponent<MinionSpawner>().SpawnMinion(ability4);
                    break;
                case Controllers.Projectile:
                    ability4Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability4);
                    break;
                default:
                    ability4Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability4);
                    break;
            }
        }

        if (Input.GetKeyDown(dashKey))
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

        //if (ability1 != null)
        //{
        //    if (ability1.GetComponent<Projectile>())
        //    {
        //        ability1Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //    else if (ability1.GetComponent<Shield>())
        //    {
        //        ability1Controller = Instantiate(shieldSpawner, transform, false);
        //    }
        //    else if (ability1.GetComponent<Minion>())
        //    {
        //        ability1Controller = Instantiate(minionSpawner, transform, false);
        //    }

        //}
        //if (ability2 != null)
        //{
        //    if (ability2.GetComponent<Projectile>())
        //    {
        //        ability2Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //    else if (ability2.GetComponent<Shield>())
        //    {
        //        ability2Controller = Instantiate(shieldSpawner, transform, false);
        //    }
        //    else if (ability2.GetComponent<Minion>())
        //    {
        //        ability2Controller = Instantiate(minionSpawner, transform, false);
        //    }
        //}
        //if (ability3 != null)
        //{
        //    if (ability3.GetComponent<Projectile>())
        //    {
        //        ability3Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //    else if (ability3.GetComponent<Shield>())
        //    {
        //        ability3Controller = Instantiate(shieldSpawner, transform, false);
        //    }
        //    else if (ability3.GetComponent<Minion>())
        //    {
        //        ability3Controller = Instantiate(minionSpawner, transform, false);
        //    }
        //}
        //if (ability4 != null)
        //{
        //    if (ability4.GetComponent<Projectile>())
        //    {
        //        ability4Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //    else if (ability4.GetComponent<Shield>())
        //    {
        //        ability4Controller = Instantiate(shieldSpawner, transform, false);
        //    }
        //    else if (ability4.GetComponent<Minion>())
        //    {
        //        ability4Controller = Instantiate(minionSpawner, transform, false);
        //    }
        //}

        //without using a list?
        if (ability1 != null)
        {
            if (ability1.GetComponent<Ability>())
            {
                Ability thisAbility = ability1.GetComponent<Ability>();

                switch (thisAbility.GetController())
                {
                    case 2:
                        ability1Controller = Instantiate(shieldSpawner, transform, false);
                        controller1 = Controllers.Shield;
                        break;
                    case 1:
                        ability1Controller = Instantiate(minionSpawner, transform, false);
                        controller1 = Controllers.Minion;
                        break;
                    case 0:
                        ability1Controller = Instantiate(projectileSpawner, transform, false);
                        controller1 = Controllers.Projectile;
                        break;
                    default:
                        ability1Controller = Instantiate(projectileSpawner, transform, false);
                        controller1 = Controllers.Projectile;
                        break;
                }
            }
        //    if (ability1.GetComponent<Projectile>())
        //    {
        //        ability1Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //    else if (ability1.GetComponent<Minion>())
        //    {
        //        ability1Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //    else if (ability1.GetComponent<Shield>())
        //    {
        //        ability1Controller = Instantiate(shieldSpawner, transform, false);
        //    }
        }
        if (ability2.GetComponent<Ability>())
        {
            int controllerType = ability2.GetComponent<Ability>().GetController();

            switch (controllerType)
            {
                case 2:
                    ability2Controller = Instantiate(shieldSpawner, transform, false);
                    controller2 = Controllers.Shield;
                    break;
                case 1:
                    ability2Controller = Instantiate(minionSpawner, transform, false);
                    controller2 = Controllers.Minion;
                    break;
                case 0:
                    ability2Controller = Instantiate(projectileSpawner, transform, false);
                    controller2 = Controllers.Projectile;
                    break;
                default:
                    ability2Controller = Instantiate(projectileSpawner, transform, false);
                    controller2 = Controllers.Projectile;
                    break;

            }
        }
        //if (ability2 != null)
        //{
        //    if (ability2.GetComponent<Projectile>())
        //    {
        //        ability2Controller = Instantiate(projectileSpawner, transform, false);
        //    }
        //}
        if (ability3.GetComponent<Ability>())
        {
            int controllerType = ability3.GetComponent<Ability>().GetController();

            switch (controllerType)
            {
                case 2:
                    ability3Controller = Instantiate(shieldSpawner, transform, false);
                    controller3 = Controllers.Shield;
                    break;
                case 1:
                    ability3Controller = Instantiate(minionSpawner, transform, false);
                    controller3 = Controllers.Minion;
                    break;
                case 0:
                    ability3Controller = Instantiate(projectileSpawner, transform, false);
                    controller3 = Controllers.Projectile;
                    break;
                default:
                    ability3Controller = Instantiate(projectileSpawner, transform, false);
                    controller3 = Controllers.Projectile;
                    break;

            }
        }
        //if (ability3 != null)
        //{
        //    if (ability3.GetComponent<Shield>())
        //    {
        //        ability3Controller = Instantiate(shieldSpawner, transform, false);
        //    }
        //}
        if (ability4.GetComponent<Ability>())
        {
            int controllerType = ability4.GetComponent<Ability>().GetController();

            switch (controllerType)
            {
                case 2:
                    ability4Controller = Instantiate(shieldSpawner, transform, false);
                    controller4 = Controllers.Shield;
                    break;
                case 1:
                    ability4Controller = Instantiate(minionSpawner, transform, false);
                    controller4 = Controllers.Minion;
                    break;
                case 0:
                    ability4Controller = Instantiate(projectileSpawner, transform, false);
                    controller4 = Controllers.Projectile;
                    break;
                default:
                    ability4Controller = Instantiate(projectileSpawner, transform, false);
                    controller4 = Controllers.Projectile;
                    break;

            }
        }
        //if (ability4 != null)
        //{
        //    if (ability4.GetComponent<Minion>())
        //    {
        //        ability4Controller = Instantiate(minionSpawner, transform, false);
        //    }
        //}
    }

    private void ActivateAbility1()
    {
        if (Input.GetKeyDown(ability1Key) && ability1OnCooldown == false)
        {
            ability1OnCooldown = true;
            ability1Image.fillAmount = 1;

            switch (controller1)
            {
                case Controllers.Shield:
                    ability1Controller.GetComponent<ShieldSpawner>().SpawnShield();
                    
                    break;
                case Controllers.Minion:
                    ability1Controller.GetComponent<MinionSpawner>().SpawnMinion(ability1);
                    
                    break;
                case Controllers.Projectile:
                    ability1Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability1);
                    
                    Debug.Log(ability1OnCooldown);
                    break;
                default:
                    ability1Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability1);
                    
                    break;
            }
        }

        if (ability1OnCooldown)
        {
            ability1Image.fillAmount -= 1 / ability1Cooldown * Time.deltaTime;

            if (ability1Image.fillAmount <= 0)
            {
                ability1Image.fillAmount = 0;
                ability1OnCooldown = false;
            }
        }
    }

}
