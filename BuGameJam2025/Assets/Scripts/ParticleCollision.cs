using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    [SerializeField] BossHealth bossHealth;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle collided with " + other.name);
        if (other.CompareTag("Boss"))
        {
            bossHealth.isDamage = true;
            bossHealth.Damage(2);
            Debug.Log("Boss Health: " + bossHealth.currentHealth);
            
        }
    }

    private void Start()
    {
        bossHealth = bossHealth.GetComponent<BossHealth>();
        if (bossHealth == null)
        {
            Debug.Log("No bossHealth Found");
        }
    }
}
