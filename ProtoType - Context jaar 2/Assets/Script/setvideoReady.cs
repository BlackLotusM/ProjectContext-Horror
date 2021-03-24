using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class setvideoReady : MonoBehaviour
{
    bool startt = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.GetComponent<VideoPlayer>().playbackSpeed = 1;
        }

        if (startt) {
            this.GetComponent<VideoPlayer>().playbackSpeed -= 0.0008f;
            if(this.GetComponent<VideoPlayer>().playbackSpeed == 0)
            {
                startt = false;
            }
        }
    }


}
