using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick : MonoBehaviour
{
    public GameObject player;
    public GameObject otherObject;
    public bool clicked;
    public int clicedint;
    public bool setActive;
    public LineRenderer lr;
    public ParticleSystem ps;

    public Light l1;
    public Light l2;
    public Light l3;

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            clicked = true;
        }
    }

    private void Update()
    {
        if(setActive && !clicked)
        {
            ps.gameObject.SetActive(true);
        }
        else
        {
            ps.gameObject.SetActive(false);
        }
        bool t = otherObject.GetComponent<onclick>().clicked;
        if (t && setActive)
        {
            
            if (clicked)
            {
                lr.enabled = true;
                l1.intensity = 1;
                l2.intensity = 1;
                l3.intensity = 1;
            }
        }
        else
        {
            lr.enabled = false;
            l1.intensity = 0;
            l2.intensity = 0;
            l3.intensity = 0;
            if (clicked)
            {
                if (Input.GetMouseButtonDown(0)) { 
                    clicedint++;
                }
                if (Input.GetMouseButtonDown(0) == true && clicedint == 2)
                {
                    clicedint = 0;
                    Debug.Log("test");
                    clicked = false;
                }
            }
        }
    }
}
