using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject player;
    public float deltaX;
    private float deltaX2;
    public float force;
    public bool isRight, isLeft, rightIsOpen;

    public bool xDirectionChange, isAgainstBox, ChangeRotation, isLever, otherWall;
   

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Dragable")
        {
            isAgainstBox = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Dragable")
        {
            isAgainstBox = false;
        }
    }
    private void OnMouseDown()
    {
        if (isLever)
        {
            force = Camera.main.transform.rotation.x;
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (Vector3.Distance(transform.position, player.transform.position) <= 6.01f)
            {
                deltaX = (player.transform.eulerAngles.y + player.transform.eulerAngles.y);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            isRight = false;
            isLeft = true;
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            isRight = true;
            isLeft = false;
        }
        else
        {
            if (!Input.GetMouseButton(0))
            {
                Debug.Log("test");
                isRight = false;
                isLeft = false;
            }
        }
    }


    public float smooth = 1f;
    private void OnMouseDrag()
    {
        if (rightIsOpen)
        {
            if (isRight)
            {
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 4)
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 6 * 6) * 8 * Time.deltaTime);
                }
            }
            if (isLeft)
            {
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 4)
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(transform.rotation.x, transform.rotation.y, -6 * 6) * 8 * Time.deltaTime);
                }
            }

        }
        else
        {
            if (isRight)
            {
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 4)
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -6 * 6) * 8 * Time.deltaTime);
                }
            }
            if (isLeft)
            {
                if (this.GetComponent<Rigidbody>().velocity.magnitude < 4)
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,6 * 6) * 8 * Time.deltaTime);
                }
            }
        }
    }
}
