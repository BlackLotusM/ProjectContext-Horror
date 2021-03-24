using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFix : MonoBehaviour
{
    public bool startActive;
    public bool baterij;
    public bool lever;
    public bool fuse;
    public Light[] thisRoom;
    public LightColManager mannager;

    public AudioSource powerUp;
    public AudioSource powerDown;

    public bool firstRoom;
    public door door;

    public bool wasActive;

    private void Update()
    {
        if(baterij && lever && fuse)
        {
            if (!startActive)
            {
                foreach (Light l in thisRoom)
                {
                    l.gameObject.SetActive(true);
                }
            }
            if (!wasActive)
            {
                if (firstRoom)
                {
                    door.doorOpen = true;
                }
                powerUp.Play();
                mannager.level -= 1;
                wasActive = true;
            }
        }
        else
        {
            if (!startActive)
            {
                foreach (Light l in thisRoom)
                {
                    l.gameObject.SetActive(false);
                }
            }
        }
    }
}
