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
       /* DisableIfNotNull(picture);
        DisableIfNotNull(brother);
        DisableIfNotNull(sister);
        DisableIfNotNull(mother);
        DisableIfNotNull(father);
        DisableIfNotNull(cat);

        picture = picture ?? GameObject.Find("Picture");
        brother = brother ?? GameObject.Find("Brother");
        sister = sister ?? GameObject.Find("Sister");
        mother = mother ?? GameObject.Find("Mother");
        father = father ?? GameObject.Find("Father");
        cat = cat ?? GameObject.Find("Cat");*/

        picture.SetActive(false);
        brother.SetActive(false);
        sister.SetActive(false);
        mother.SetActive(false);
        father.SetActive(false);
        cat.SetActive(false);
    }

   /* private void DisableIfNotNull(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
        }
        else
        {
            Debug.LogError($"{obj} is not assigned in {gameObject.name}!");
        }
    }
   */
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
