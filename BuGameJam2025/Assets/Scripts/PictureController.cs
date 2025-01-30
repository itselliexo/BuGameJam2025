using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R pressed");
            picture.SetActive(!picture.activeSelf);
        }
    }
}
