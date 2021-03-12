using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class GrabObjects : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    private float Speed;
    private bool grabbed = false;
    private Rigidbody rb;
    public float offset = 6;

    //Futute related
        //private float maxSpeed;
        //private float minSpeed;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        grabbed = true;
        Debug.Log("Click");
    }

    
    void OnMouseDrag()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 6)
        {
            //Cam pos plus richting plus extra offset om het voor het scherm te zetten en dat min het object
            Vector3 heading = ((Camera.main.transform.position + Camera.main.transform.forward * offset) - transform.position);
            if (rb.velocity.magnitude < 10)
            {
                rb.AddForce(heading * Speed * Time.deltaTime);
            }
        }
        else
        {
            grabbed = false;
        }
    }

    private void Update()
    {   //Checks For releasex
        if (Input.GetMouseButtonUp(0))
        {
            grabbed = false;
            rb.isKinematic = false;
            rb.drag = 0;
        }

        //Slows down when close to point
        if (grabbed)
        {
            if (Vector3.Distance(Camera.main.transform.position + Camera.main.transform.forward * offset, this.transform.position) < 0.60f)
            {
                rb.drag = rb.drag + 0.2f;
            }
            else if (Vector3.Distance(Camera.main.transform.position + Camera.main.transform.forward * offset, this.transform.position) < 1f)
            {
                rb.drag = 2;
            }
            else
            {
                rb.drag = 0.8f;
            }
        }
        //ToDo maybe add a feature that drops the block when its to far from you
    }
}