using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] float defaultSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float smoothingTime;
    [SerializeField] GameObject cameraObj;
    private float currentHorizontalVelocity;
    //float updateTime = 1f;
    //float timeSinceUpdate = 0f;
    public StaminaBar staminaBar;

    [SerializeField] CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 currentDirection;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeed;
        Time.timeScale = 1;
        
        StaminaBar staminaBar = gameObject.GetComponent<StaminaBar>();
        if (staminaBar == null)
        {
            Debug.Log("No StaminaBar Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        /* timeSinceUpdate += Time.deltaTime;
         if (timeSinceUpdate > updateTime)
         {
             Debug.Log(speed);
             timeSinceUpdate = 0f;
         }*/
    }

    private void Movement()
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

        Vector3 smoothedDirection = Vector3.SmoothDamp(currentDirection, targetDirection, ref currentDirection, smoothingTime);

        smoothedDirection.y = 0f;

        characterController.Move(smoothedDirection * speed * Time.deltaTime);

        if (jump > 0 && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.fixedDeltaTime;
        characterController.Move(velocity * Time.fixedDeltaTime);

        if (isGrounded)
        {
            if (moveZ > 0 && sprint > 0)
            {
                staminaBar.depleting = true;
                staminaBar.regenerating = false;
                if (staminaBar.currentStamina > 1)
                {
                    speed = sprint > 0 ? sprintSpeed : defaultSpeed;
                }
                else
                {
                    speed = defaultSpeed;
                }
                
            }
            else if (moveZ < 0)
            {
                speed = moveZ < 0 ? backwardsSpeed : defaultSpeed;
                staminaBar.depleting = false;
                staminaBar.regenerating = true;
            }
            else
            {
                speed = defaultSpeed;
                staminaBar.depleting = false;
                staminaBar.regenerating = true;
            }
        }
    }
}
