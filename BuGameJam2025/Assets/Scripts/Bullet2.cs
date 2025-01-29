using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 10;
    [SerializeField] private float bulletLifeTime = 0.5f;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //compare tag, if collision tag is minion, reduce minions health
        /*if (collision.gameObject.CompareTag("Minion"))
        {
            MinionsController minion = collision.gameObject.GetComponent<MinionsController>();
            if (minion != null)
            {
                minion.TakeDamage(bulletDamage); 
                Destroy(gameObject);
                Debug.Log("hit");
            }
        }*/
       
       // else
        //{
            Destroy(gameObject);
       // }
    }
}
