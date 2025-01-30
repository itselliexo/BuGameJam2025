using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    private Animator animator;
    [SerializeField] private float regenTimer;
    [SerializeField] private float healthTimer;
    [SerializeField] private float healthTick = 2f;
    [SerializeField] private float timeUntilRegen;
    [SerializeField] private int regenAmount;
<<<<<<< Updated upstream
    [SerializeField] private float timeSinceLastDamaged;
=======
    [SerializeField] private float damageDelay;
    [SerializeField] private GameObject picturePrefab;
    [SerializeField] private Transform spawnPoint;
    
    private float lastDamageTime;   
    
    
    //[SerializeField] private float timeSinceLastDamaged;
>>>>>>> Stashed changes

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
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
            HandleDeath();
        }
        
    }

    public void Damage(int damage)
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

    public void HandleDeath()
    {
        Instantiate(picturePrefab, spawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
<<<<<<< Updated upstream
        Debug.Log("Boss Defeated");
=======

>>>>>>> Stashed changes
    }
}
