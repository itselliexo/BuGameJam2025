using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth = 20;
    [SerializeField] int healthRegen;
    [SerializeField] float regenDelay;
    float healthClock;

    private float timeSinceLastDamage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Damage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        timeSinceLastDamage = 0f;
    }
    void HealthRegen()
    {
        if (timeSinceLastDamage >= regenDelay)
        {
            currentHealth += healthRegen;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }
    public void HandleDeath()
    {
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        timeSinceLastDamage += Time.deltaTime;
        healthClock += Time.deltaTime;
        if (healthClock >= 1f)
        {
            HealthRegen();
            healthClock = 0f;
        }
        HandleDeath();
    }
}
