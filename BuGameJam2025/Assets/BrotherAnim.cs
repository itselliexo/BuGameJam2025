using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {

        // Get the Animator component attached to the player
         animator = GetComponent<Animator>();

        if (animator != null)
        {
            // Set the default animation trigger or state
            animator.Play("Default"); // Replace "DefaultAnimationName" with your actual animation name
        }
        else
        {
            Debug.LogWarning("Animator component not found on this object.");
        }
    }
}
