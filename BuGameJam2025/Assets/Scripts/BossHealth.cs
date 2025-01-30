using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    //private Animator animator;
    public bool isDamage = false;
    [SerializeField] private float regenTimer;
    [SerializeField] private float healthTimer;
    [SerializeField] private float healthTick = 2f;
    [SerializeField] private float timeUntilRegen;
    [SerializeField] private int regenAmount;
    [SerializeField] private float damageDelay;
    private float lastDamageTime;   
    
    
    //[SerializeField] private float timeSinceLastDamaged;

    void Start()
    {
        currentHealth = maxHealth;
        //animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        regenTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;
        
        //timeSinceLastDamaged += Time.deltaTime;
        //if (regenTimer >= timeUntilRegen)
        //{
            //RegenHealth();
        //}
        //if purifier.raycast == true
        //Damage();
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
        
    }

    public void Damage(int damage)
    {
        if (Time.time >= lastDamageTime + damageDelay)
        {
            lastDamageTime = Time.time;
            isDamage = true;
            if (isDamage)
            {
                currentHealth -= damage;
                lastDamageTime = Time.time;
            }
        }
        else
        {
            isDamage = false;
        }
    }

    void RegenHealth()
    {
        if (healthTimer >= healthTick && currentHealth < maxHealth)
        {
            currentHealth += regenAmount;
            healthTimer = 0f;
        }
    }

    public void HandleDeath()
    {
        Destroy(gameObject);
        Debug.Log("Boss Defeated");
    }
}
