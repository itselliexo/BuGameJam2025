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
    [SerializeField] private List<GameObject> collectablePrefabs;
    [SerializeField] private int bossIndex = 0;
    private float lastDamageTime;   
    Vector3 offset = new Vector3(0, 1, 0);
    
    //[SerializeField] private float timeSinceLastDamaged;

    void Start()
    {
        currentHealth = maxHealth;
        //animator = GetComponent<Animator>();
        collectablePrefabs = new List<GameObject>();

        Object[] loadedCollectablePrefabs = Resources.LoadAll("Collectables", typeof(GameObject));

        foreach (GameObject obj in loadedCollectablePrefabs)
        {
            if (obj is GameObject)
            {
                collectablePrefabs.Add(obj);
            }
        }
        if (collectablePrefabs.Count <= 0)
        {
            Debug.Log("No collectable prefabs in list");
        }
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

        if (collectablePrefabs.Count == 0)
        {
            Debug.Log("No Prefabs in collectables folder");
            return;
        }
        if (bossIndex < 0 || bossIndex >= collectablePrefabs.Count)
        {
            Debug.LogError($"bossIndex {bossIndex} is out of range!");
            return;
        }
        /*GameObject newCollectable = Instantiate(collectablePrefabs[bossIndex], gameObject.transform.position + offset, Quaternion.identity);
        newCollectable.SetActive(true);
        Debug.Log($"Boss dropped collectable: {newCollectable.name}");*/

        Debug.Log("Boss Defeated");
    }
}
