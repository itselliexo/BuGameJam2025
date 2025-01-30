using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float playerHealth = 100f;
    [SerializeField] private GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        if (loseScreen != null)
        { 
            loseScreen.SetActive(false);
        }
        //Debug.Log(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerHealth);
        if (playerHealth <= 0)
        {
            HandlePlayerDeath();
        }
    }

    void HandlePlayerDeath()
    {
        loseScreen.SetActive(true);
        Debug.Log("Game Over");
        Time.timeScale = 0;
         
    }
    //Changes: I moved the debug statement into its own method so we can call it instead of having all the death logic in the update function
}