using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoriffle : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private Transform firePointTransform;
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private float fireRate = 0.1f; // Daha hızlı ateş edebilmesi için fire rate düşürüldü

    private float shootTimer = 1f;

    void Update()
    {
        shootTimer += Time.deltaTime;

        // 🔥 Sol tık basılı tutulduğunda otomatik ateş et
        if (Input.GetButton("Fire1") && shootTimer >= fireRate)
        {
            Fire2();
            shootTimer = 0;
        }
    }

    private void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePointAuto");
        /*firePointTrsnsform = GameObject.FindGameObjectWithTag("FirePoint").transform;*/
        firePointTransform = firePoint.GetComponent<Transform>();
    }

    public void Fire2()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Bullet prefab or fire point is not assigned!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePointTransform.position, firePointTransform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.AddForce(firePointTransform.forward * bulletSpeed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("The bullet prefab does not have a Rigidbody component!");
        }
    }
}
