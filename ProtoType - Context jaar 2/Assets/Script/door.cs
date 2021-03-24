using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Animator anim;
    public bool doorOpen;
    public bool doorCheck;
    public float getValue;
    public float setValue;
    public bool Box;
    public bool firstDoor;
    public LookAndMove lm;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;

    private void Start()
    {
        lm = FindObjectOfType<LookAndMove>();
        doorCheck = doorOpen;
        anim = GetComponent<Animator>();
        anim.SetFloat("Blend", 0);
    }

    private void Update()
    {
        if(doorCheck != doorOpen)
        {
            doorCheck = doorOpen;
            if (doorOpen)
            {
                doorOpenSound.Play();
            }
            else
            {
                doorCloseSound.Play();
            }
        }

        getValue = anim.GetFloat("Blend");
            if (Box)
            {
                doorOpen = false;
                if (getValue > 0)
                {
                    setValue -= 0.01f;
                    anim.SetFloat("Blend", setValue);
                }
            }
            else
            {
                if (doorOpen && getValue < 1)
                {
                    setValue += 0.01f;
                    anim.SetFloat("Blend", setValue);
                }
                else
                {
                    if (getValue > 0)
                    {
                        setValue -= 0.01f;
                        anim.SetFloat("Blend", setValue);
                    }
                }
            }
    }

    private void OnMouseDown()
    {
        if (lm.canMove)
        {
            if (!firstDoor)
            {
                doorOpen = !doorOpen;
            }
        }
    }
}
