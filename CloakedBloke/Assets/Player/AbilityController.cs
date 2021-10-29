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


    //Dictionary<Types, >

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ability1Key))
        {
            //ability1Controller.fireProjectile();
        }
        if (Input.GetKeyDown(ability2Key))
        {
            //ability2Controller1.fireProjectile();
        }
    }

    private void UpdateAbilityControls()
    {

    }
}
