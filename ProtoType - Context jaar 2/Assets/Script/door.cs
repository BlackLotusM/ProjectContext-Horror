using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject player;
    public Vector3 test;
    public float deltaX;
    public float deltaX2;
    public float force;

    public bool xDirectionChange;
    public bool ChangeRotation;
    private void OnMouseDown()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (Vector3.Distance(transform.position, player.transform.position) <= 6.01f)
        {
            deltaX = (player.transform.rotation.y + player.transform.rotation.y);
        }
    }

    private void OnMouseDrag()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 6.01f)
        {
            if (this.GetComponent<Rigidbody>().velocity.magnitude < 1)
            {
                deltaX2 = (player.transform.rotation.y + player.transform.rotation.y);
                if (xDirectionChange)
                {
                    force = deltaX - deltaX2;
                }
                else
                {
                    force = deltaX2 - deltaX;
                }

                if (ChangeRotation)
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(force * 200, 0, 0));
                }
                else
                {
                    this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, force * 200));
                }
            }
        }
    }
}
