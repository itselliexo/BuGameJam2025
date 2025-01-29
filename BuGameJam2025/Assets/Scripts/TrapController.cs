using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrapController : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab; // Fırlatılacak trap prefab'i
    [SerializeField] private Transform dropPoint;   // Trap Location
    [SerializeField] private float dropForce = 5f;  // Trap power
    [SerializeField] private float trapCooldown = 3f; // Cooldown timer 

    private bool canDropTrap = true; // Check trap status 

    private void Update()
    {
        /*
        if (dropPoint != null)
        {
            dropPoint.position = transform.position + transform.forward * 2f;  // throw the trap +2 px
        }
        */

        // Press X
        if (Input.GetKeyDown(KeyCode.X) && canDropTrap)
        {
            DropTrap();
            Debug.Log("Drop The Trap!");
        }
    }

    private void Start()
    {
        if (dropPoint == null)
        {
            dropPoint = GameObject.FindGameObjectWithTag("DropPoint").transform;
        }

        GameObject[] allPrefabs = Resources.LoadAll<GameObject>("Prefabs");

        foreach (GameObject prefab in allPrefabs)
        {
            if (prefab.CompareTag("Trap"))
            {
                trapPrefab = prefab;
            }
        }
    }

    private void DropTrap()
    {
        if (trapPrefab == null || dropPoint == null)
        {
            Debug.LogWarning("Trap Prefab or Drop Point is not assigned!");
            return;
        }

        // Create a Trap
        GameObject spawnedTrap = Instantiate(trapPrefab, dropPoint.position, dropPoint.rotation);

        // Touch the Trap
        Rigidbody trapRigidbody = spawnedTrap.GetComponent<Rigidbody>();
        if (trapRigidbody != null)
        {
            trapRigidbody.AddForce(dropPoint.forward * dropForce, ForceMode.Impulse);
        }

        // Start Cooldown
        canDropTrap = false;
        StartCoroutine(ResetTrapCooldown());
    }

    private IEnumerator ResetTrapCooldown()
    {
        yield return new WaitForSeconds(trapCooldown);
        canDropTrap = true; // Cooldown time is over, trap can be placed again
    }
}
