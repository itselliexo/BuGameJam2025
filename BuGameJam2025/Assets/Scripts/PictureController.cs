using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
{
    [SerializeField] private GameObject picture;
    [SerializeField] private GameObject brother;
    [SerializeField] private GameObject sister;
    [SerializeField] private GameObject mother;
    [SerializeField] private GameObject father;
    [SerializeField] private GameObject cat;

    // Start is called before the first frame update
    void Start()
    {
        picture.SetActive(false);
        brother.SetActive(false);
        sister.SetActive(false);
        mother.SetActive(false);
        father.SetActive(false);
        cat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("R pressed");
            picture.SetActive(!picture.activeSelf);
        }
    }
}
