using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGate : MonoBehaviour
{
    [SerializeField]
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (sceneName != null && other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
