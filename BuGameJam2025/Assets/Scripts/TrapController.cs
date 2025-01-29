using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrapController : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab; // Fırlatılacak trap prefab'i
    [SerializeField] private Transform dropPoint;   // Trap Location
    [SerializeField] private float dropForce = 5f;  // Trap power

    private void Update()
    {
        /*
        if (dropPoint != null)
        {
            dropPoint.position = transform.position + transform.forward * 2f;  // throw the trap +2 px
        }
        */

        // Press X
        if (Input.GetKeyDown(KeyCode.X))
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
            Debug.LogWarning("Trap Prefab veya Drop Point atanmadı!");
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
    }

}
