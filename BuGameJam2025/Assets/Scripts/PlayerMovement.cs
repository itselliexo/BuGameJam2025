using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentSpeed;
    [SerializeField] float defaultSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float smoothingTime = 1f;
    private float currentHorizontalVelocity;

    [SerializeField] CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 currentDirection;
    private Vector3 smoothedVelocity;

    public StaminiaBar staminaBar;

    void Start()
    {
        currentSpeed = defaultSpeed;
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
        StaminiaBar staminaBar = GetComponent<StaminiaBar>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        float sprint = Input.GetAxis("Sprint");

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            currentHorizontalVelocity = Mathf.Lerp(currentHorizontalVelocity, 0f, Time.deltaTime / smoothingTime);
        }
        else
        {
            currentHorizontalVelocity = moveX;
        }

        Vector3 targetDirection = transform.right * currentHorizontalVelocity + transform.forward * moveZ;
        targetDirection = targetDirection.normalized;

        currentDirection = Vector3.SmoothDamp(currentDirection, targetDirection, ref smoothedVelocity, smoothingTime);
        

        characterController.Move(currentDirection * currentSpeed * Time.deltaTime);

        if (jump > 0 && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (isGrounded)
        {
            if (moveZ > 0 && sprint > 0)
            {
                staminaBar.depleting = true;
                staminaBar.regenerating = false;
                if (staminaBar.currentStamina >=1)
                {
                    currentSpeed = sprint > 0 ? sprintSpeed : defaultSpeed;
                }
                else
                {
                    currentSpeed = defaultSpeed;
                }
                
            }
            else if (moveZ < 0)
            {

                currentSpeed = moveZ < 0 ? backwardsSpeed : defaultSpeed;
                staminaBar.depleting = false;
                staminaBar.regenerating = true;

            }
            else
            {
                currentSpeed = defaultSpeed;
                staminaBar.depleting = false;
                staminaBar.regenerating = true;
            }
        }
    }
}
