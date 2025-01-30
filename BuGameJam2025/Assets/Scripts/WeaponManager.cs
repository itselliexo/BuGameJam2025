using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject shoot;  // İlk silah (tekli atış)
    public GameObject autoRifle;    // İkinci silah (otomatik atış)

    private int currentWeapon = 0;  // 0 = ShootWeapon, 1 = AutoRifle

    void Start()
    {
        if (shoot == null)
        {
            shoot = GameObject.FindGameObjectWithTag("Shoot");
        }
        if (autoRifle == null)
        {
            autoRifle = GameObject.FindGameObjectWithTag("AutoRifle");
        }

        SwitchWeapon(0); // Başlangıçta birinci silahı seç
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);  // 1'e basınca tek atışlı silah
            Debug.LogWarning("Silah 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);  // 2'ye basınca AutoRifle
            Debug.LogWarning("Silah 2");
        }
    }

    void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex == 0)
        {
            shoot.SetActive(true);
            autoRifle.SetActive(false);
        }
        else if (weaponIndex == 1)
        {
            shoot.SetActive(false);
            autoRifle.SetActive(true);
        }

        currentWeapon = weaponIndex;
    }
}
