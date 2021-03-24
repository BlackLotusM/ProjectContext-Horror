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
    public float rotationX = 0;

    public RoomFix rf;

    public bool canMove; //= true;
    Camera playerCamera;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;


    void Start()
    {
        playerCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public IEnumerator startPowerOutage()
    {
        yield return new WaitForSeconds(2);
        rf.powerDown.Play();
        rf.mannager.level++;
        rf.startActive = false;
    }

    public void canMoveset()
    {
        canMove = true;
    }

    public void cantMoveset()
    {
        canMove = false;
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
    }
}
