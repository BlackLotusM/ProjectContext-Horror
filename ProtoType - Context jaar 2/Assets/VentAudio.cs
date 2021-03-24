using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentAudio : MonoBehaviour
{
    public bool isPlaying;
    public AudioSource asvent;
    private void OnTriggerEnter(Collider other)
    {
        if (!isPlaying)
        {
            if (other.gameObject.tag == "Player")
            {
                isPlaying = true;
                asvent.Play();
            }
        }
    }

    private void Update()
    {
    }
}
