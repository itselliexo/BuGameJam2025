using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifyingGun2 : MonoBehaviour
{
    [Header("Shooting Settings")]
    //[SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private Transform firePointTransform;
    [SerializeField] private ParticleSystem purifyEffect;
    //[SerializeField] private float bulletSpeed = 20f;
    //[SerializeField] float fireRate = 0.5f;

    //private float shootTimer;
    void Update()
    {
        //shootTimer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            purifyEffect.Stop();
        }
    }

    private void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint");
        firePointTransform = firePoint.GetComponent<Transform>();
        if (purifyEffect == null)
        {
            purifyEffect = purifyEffect.GetComponent<ParticleSystem>();
        }
    }

    public void Fire()
    {
        purifyEffect.Play();
    }
}
