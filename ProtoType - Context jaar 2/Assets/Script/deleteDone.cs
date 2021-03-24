using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteDone : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<AudioSource>().Play();

    }
    private void Update()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
