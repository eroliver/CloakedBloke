using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to hold player data, manage player info and ensure player information is not lost
public class Player : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        player = gameObject;

        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayer()
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
