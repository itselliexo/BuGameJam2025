using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurifierGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxRange;
    [SerializeField] protected AudioSource hitSource;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float spreadAngle = 1f;
    [SerializeField] private int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetRandomDirection()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle * Mathf.Tan(Mathf.Deg2Rad * spreadAngle);

        Vector3 spreadOffset = new Vector3(randomCirclePoint.x, randomCirclePoint.y, 1).normalized;

        return cameraTransform.TransformDirection(spreadOffset);
    }
    public void Shoot()
    {
        Vector3 randomDirection = GetRandomDirection();

        Debug.DrawRay(firePoint.position, randomDirection * maxRange, Color.red, 1f);

        if (Physics.Raycast(firePoint.position, randomDirection, out RaycastHit hit, maxRange))
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

        }
    }
}
