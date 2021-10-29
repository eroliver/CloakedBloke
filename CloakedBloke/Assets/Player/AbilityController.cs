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
    private GameObject abilitySpawner;
    [SerializeField]
    private GameObject minionSpawner;
    //ability controllers
    private GameObject ability1Controller;
    private GameObject ability2Controller;
    private GameObject ability3Controller;
    private GameObject ability4Controller;
    private GameObject ability5Controller;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAbilityControls();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ability1Key))
        {
            ability1Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability1);
        }
        
        if (Input.GetKeyDown(ability2Key))
        {
            ability2Controller.GetComponent<ProjectileSpawner>().fireProjectile(ability2);

        }
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
    }


}
