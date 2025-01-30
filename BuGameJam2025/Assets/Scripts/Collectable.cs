using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject picture;
    // Start is called before the first frame update
    void Start()
    {
        picture.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            picture.SetActive(true);
            Destroy(gameObject);
        }
    }
}
