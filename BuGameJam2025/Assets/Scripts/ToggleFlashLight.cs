using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFlashLight : MonoBehaviour
{
    [SerializeField] private GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        flashLight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }
}
