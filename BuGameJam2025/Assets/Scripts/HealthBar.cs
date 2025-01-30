using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private RectTransform healthBar;

    public static bool takeDamage = false;
    private float originalWidth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        originalWidth = healthBar.sizeDelta.x;
        if (playerController == null)
        {
            Debug.Log("No playerController Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        if (playerController.playerHealth < playerController.maxHealth && takeDamage && playerController.playerHealth >= 0)
        {
            float healthPercentage = (playerController.playerHealth / playerController.maxHealth);
            //Debug.Log("playerHealth" + playerController.playerHealth);
            //Debug.Log("maxHealth" + playerController.maxHealth);
            //Debug.Log("healthPercentage" + healthPercentage);
            //Debug.Log(playerController.playerHealth);
            healthBar.sizeDelta = new Vector2(originalWidth * healthPercentage, healthBar.sizeDelta.y);
            //Debug.Log(healthBar.offsetMax.x);
            takeDamage = false;
        }

    }
}
