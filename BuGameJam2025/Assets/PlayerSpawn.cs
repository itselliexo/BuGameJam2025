using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        // Find the spawn point by its tag (make sure the tag is assigned in Unity)
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawner")?.transform;
            if (spawnPoint == null)
            {
                Debug.LogError("PlayerSpawner tag not found! Please assign the correct tag to the spawn point.");
            }
        }

        // Find the player by its tag (make sure the tag is assigned in Unity)
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player tag not found! Please assign the correct tag to the player.");
            }
        }

        // If both player and spawn point are found, set the player's position
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
        }
    }
}
