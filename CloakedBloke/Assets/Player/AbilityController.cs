using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle all input from the player that is related to abilites to avoid adding complexity to the movement scripts
public class AbilityController : MonoBehaviour
{
    [SerializeField]
    private KeyCode abilityKey1 = KeyCode.Mouse0;

    private ProjectileController projectileController;

    // Start is called before the first frame update
    void Start()
    {
        projectileController = GetComponentInChildren<ProjectileController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(abilityKey1))
        {
            projectileController.fireProjectile();
        }
    }
}
