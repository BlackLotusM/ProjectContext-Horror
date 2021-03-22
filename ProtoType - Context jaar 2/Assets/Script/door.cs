using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    Animator anim;
    public bool doorOpen;
    public float getValue;
    public float setValue;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Blend", 0);
    }

    private void Update()
    {
        getValue = anim.GetFloat("Blend");

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

    private void OnMouseDown()
    {
        doorOpen = !doorOpen;
        
    }
}
