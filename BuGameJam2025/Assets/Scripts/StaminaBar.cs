using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    public float currentStamina;
    public float maxStamina = 100;
    public bool depleting = false;
    public bool regenerating = false;
    public float depleteRate = 20f;

    public RectTransform staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        depleteStamina();
        regenerateStamina();
    }

    public void depleteStamina()
    {
        if (currentStamina >=1 && depleting)
        {
            currentStamina -= depleteRate * Time.deltaTime;
            staminaBar.offsetMax = new Vector2(staminaBar.offsetMax.x - depleteRate * Time.deltaTime, staminaBar.offsetMax.y);
        }
    }

    public void regenerateStamina()
    {
        if(currentStamina < maxStamina && regenerating)
        {
            currentStamina += depleteRate * Time.deltaTime;
            staminaBar.offsetMax = new Vector2(staminaBar.offsetMax.x + depleteRate * Time.deltaTime, staminaBar.offsetMax.y);
        }
    }
}
