using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class LookAndMove : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed = 7.5f;
    [SerializeField]
    private float gravity = 20.0f;
    [SerializeField]
    private float lookSpeed = 2.0f;
    [SerializeField]
    private float lookXLimit = 45.0f;
    float rotationX = 0;

    public bool canMove = true;
    Camera playerCamera;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;

    //Eventueel running en jumping speed
    //public float runningSpeed = 11.5f;
    //public float jumpSpeed = 8.0f;

    void Start()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {      
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (walkingSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0;
        }

        characterController.Move(moveDirection * Time.deltaTime);
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Running shortcut
            //bool isRunning = Input.GetKey(KeyCode.LeftShift);

        //Als kan bewegen dan (dit stuk) anders 0 als running dan runningspeed en anders walking speed
        //if someone would look at the code :p 

        //Eventueel met running speed
            //float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            //float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;

        //Jump part disabled
            //if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            //{
            //    moveDirection.y = jumpSpeed;
            //}
            //else
            //{
            //    moveDirection.y = movementDirectionY;
            //}
    }
}
