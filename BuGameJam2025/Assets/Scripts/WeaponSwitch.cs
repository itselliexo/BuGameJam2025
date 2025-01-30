using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject autoRifle;
    [SerializeField] private GameObject purifier;
    // Start is called before the first frame update
    void Start()
    {
        if (gun == null)
        {
            gun = GameObject.FindGameObjectWithTag("Gun");
        }
        if (autoRifle == null)
        {
            autoRifle = GameObject.FindGameObjectWithTag("AutoRifle");
        }
        if (purifier == null)
        {
            purifier = GameObject.FindGameObjectWithTag("Purifier");
        }
        gun.SetActive(true);
        autoRifle.SetActive(false);
        purifier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive(true);
            purifier.SetActive(false);
            autoRifle?.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.SetActive(false);
            purifier.SetActive(true);
            autoRifle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gun.SetActive(false);
            purifier.SetActive(false);
            autoRifle.SetActive(true);
        }
    }
}
