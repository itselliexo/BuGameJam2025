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
    [SerializeField] private BossHealth bossHealth;
    [SerializeField] private int damage = 1;
    //[SerializeField] private float bulletSpeed = 20f;
    //[SerializeField] float fireRate = 0.5f;
    [SerializeField] private Camera cameraObject;
    [SerializeField] private float spreadAngle = 1f;
    [SerializeField] private float maxRange = 100f;
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
            bossHealth.isDamage = false;
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
        if (bossHealth == null)
        {
            bossHealth = bossHealth.GetComponent<BossHealth>();
        }
        if (cameraObject == null)
        {
            cameraObject = Camera.main;
        }
    }

    /*public Vector3 GetRandomDirection()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle * Mathf.Tan(Mathf.Deg2Rad * spreadAngle);

        Vector3 spreadOffset = new Vector3(randomCirclePoint.x, randomCirclePoint.y, 1).normalized;

        return cameraObject.transform.TransformDirection(spreadOffset);
    }
    */
    public void Fire()
    {
        purifyEffect.Play();
       /* Vector3 randomDirection = GetRandomDirection();

        if (firePointTransform == null)
        {
            Debug.LogError("firePointTransform is null!");
            return;
        }

        Debug.DrawRay(firePointTransform.position, randomDirection * maxRange, Color.red, 1f);

        if (Physics.Raycast(firePointTransform.position, randomDirection, out RaycastHit hit, maxRange))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable == null)
            {
                damageable = hit.collider.GetComponentInParent<IDamageable>();
                if (damageable == null)
                {
                    Debug.Log("Missed");
                }
                if (damageable != null)
                {
                    damageable.Damage(damage);
                    if (hitSource != null)
                    {
                        hitSource.Play();
                    }
                }
            }

        }*/
    }
}
