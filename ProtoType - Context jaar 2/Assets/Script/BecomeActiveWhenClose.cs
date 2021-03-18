using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeActiveWhenClose : MonoBehaviour
{
    public GameObject Player;
    public float distance;
    public bool closeEnough;

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < distance)
        {
            closeEnough = true;
        }
        else {
            closeEnough = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2))
            {
                if (closeEnough && hit.transform.tag == "Climbable")
                {
                    Player.GetComponent<Animator>().Play("Climb");
                }

                if (closeEnough && hit.transform.tag == "Window")
                {
                    Player.GetComponent<Animator>().Play("Window");
                }
            }
        }
    }
}
