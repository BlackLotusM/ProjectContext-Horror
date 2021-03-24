using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSirene : MonoBehaviour
{
    public AudioSource siiren;
    public bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            if (other.gameObject.tag == "Player")
            {
                hasPlayed = true;
                siiren.Play();
            }
        }
    }
}
