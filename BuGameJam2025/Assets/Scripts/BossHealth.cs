using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] private float regenTimer;
    [SerializeField] private float healthTimer;
    [SerializeField] private float healthTick = 2f;
    [SerializeField] private float timeUntilRegen;
    [SerializeField] private int regenAmount;
    [SerializeField] private float timeSinceLastDamaged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        regenTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;
        timeSinceLastDamaged += Time.deltaTime;
        if (regenTimer >= timeUntilRegen)
        {
            RegenHealth();
        }
        //if purifier.raycast == true
        //Damage();
        if (currentHealth <= 0)
        {
            HandleBossDeath();
        }
        
    }

    void Damage()
    {
        timeSinceLastDamaged = 0f;
        //purifier.damage -= currentHealth;
    }

    void RegenHealth()
    {
        if (healthTimer >= healthTick)
        {
            currentHealth += regenAmount;
            healthTimer = 0f;
        }
    }

    void HandleBossDeath()
    {
        Destroy(gameObject);
        Debug.Log("Boss Defeated");
    }
}
