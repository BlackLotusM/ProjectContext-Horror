using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class finalLever : MonoBehaviour
{
    public VideoPlayer vp;
    public LookAndMove getval;
    public moveTo enemy;
    public float oldMouse;
    public musicHandeler mh;
    public bool exit;
    public VideoClip vc;

    public Light[] lights;
    public GameObject endTrigger;

    void OnMouseDown()
    {
        oldMouse = getval.rotationX;
    }

    void OnMouseDrag()
    {
        if (!exit)
        {
            oldMouse = getval.rotationX - oldMouse;
            if (oldMouse < 0)
            {
                if (oldMouse < -5)
                {
                    oldMouse = -5;
                }

                transform.Rotate(new Vector3(0, oldMouse * 4, 0) * 8 * Time.deltaTime);
            }

            if (oldMouse > 0)
            {
                if (oldMouse > 5)
                {
                    oldMouse = 5;
                }
                transform.Rotate(new Vector3(0, oldMouse * 4, 0) * 8 * Time.deltaTime);
            }
        }
    }
    private void Update()
    {
        if (transform.eulerAngles.x <= 85 && transform.eulerAngles.x >= 60)
        {
            endTrigger.SetActive(true);
            vp.clip = vc;
            vp.isLooping = true;
            exit = true;
            enemy.killEnemy();
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.white;
                
            }
            mh.secondStage();
        }
        else
        {

        }
    }
}
