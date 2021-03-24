using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public RoomFix room1;
    public RoomFix room2;
    public RoomFix room3;

    public bool open = false;

    public LookAndMove lm;
    public Camera cam;
    public Animator anim1;
    public Animator anim2;

    private void Update()
    {
        if (!open)
        {
            if(room1.wasActive && room2.wasActive && room3.wasActive)
            {
                open = true;
                StartCoroutine(openThingy());
            }
        }
    }

    IEnumerator openThingy()
    {
        lm.canMove = false;
        cam.gameObject.SetActive(true);
        anim1.enabled = true;
        anim2.enabled = true; 
        yield return new WaitForSeconds(2);
        lm.canMove = true;
        cam.gameObject.SetActive(false);
        anim1.enabled = false;
        anim2.enabled = false;
    }
}
