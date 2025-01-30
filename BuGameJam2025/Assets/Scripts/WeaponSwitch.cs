using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject purifier;
    // Start is called before the first frame update
    void Start()
    {
        gun.SetActive(true);
        purifier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.SetActive(true);
            purifier.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun.SetActive(false);
            purifier.SetActive(true);
        }
    }
}
