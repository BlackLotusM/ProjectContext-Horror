using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    public Camera secondCam;
    public LookAndMove lm;
    public GameObject beest;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            beest.SetActive(true);
            lm.canMove = false;
            secondCam.gameObject.SetActive(true);
            Camera.main.enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
