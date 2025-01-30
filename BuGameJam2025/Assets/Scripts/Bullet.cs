using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 5;
    [SerializeField] private float bulletLifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        //compare tag, if collision tag is minion, reduce minions health
        if (other.CompareTag("Minion"))
        {
            MinionHealth minion = other.GetComponent<MinionHealth>();
            //Debug.Log($"{minion} found");
            if (minion != null)
            {
                minion.Damage(bulletDamage); 
                Destroy(gameObject);
                Debug.Log("hit");
            }
        }
    }
}
