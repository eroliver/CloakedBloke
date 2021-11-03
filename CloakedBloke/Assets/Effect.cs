using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;

public class Effect : MonoBehaviour
{
    private bool isCharacter = false;
    private bool isEnemy = false;
    private AdvancedWalkerController characterMovementController;
    private AITestController enemyMovementController;
    private Effectables effectable;

    private enum Effectables
    {
        enemy,
        player,
        destructable,
        shield
    }
    // Start is called before the first frame update
    void Start()
    {
        AssignMovementController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slow(float amount, float duration)
    {
        switch (effectable)
        {
            case Effectables.enemy:
                StartCoroutine(enemyMovementController.Slow(amount, duration));
                Debug.Log("slowed enemy effect");

                break;
            case Effectables.player:
                StartCoroutine(characterMovementController.Slow(amount, duration));
                Debug.Log("slowed player effect");

                break;
            case Effectables.destructable:
                break;
            case Effectables.shield:
                break;
            default:
                break;
        }

    }

    private void AssignMovementController()
    {
        var characterMovement = GetComponent<AdvancedWalkerController>();
        var enemyMovement = GetComponent<AITestController>();

        if (characterMovement != null)
        {
            characterMovementController = characterMovement;
            effectable = Effectables.player;
        }
        else if (enemyMovement != null)
        {
            enemyMovementController = enemyMovement;
            effectable = Effectables.enemy;
        }
    }
}
