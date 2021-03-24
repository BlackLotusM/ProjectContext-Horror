using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public LookAndMove getval;
    public RoomFix rf;
    public float oldMouse;

    void OnMouseDown()
    {
        oldMouse = getval.rotationX;
    }

    void OnMouseDrag()
    {
        if (!rf.lever)
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
        //Debug.Log(this.gameObject.transform.localEulerAngles.x);
        if(transform.eulerAngles.x <= 85 && transform.eulerAngles.x >= 60)
        {
            rf.lever = true;
            Destroy(this.gameObject.GetComponent<HingeJoint>());
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            Destroy(this.gameObject.GetComponent<BoxCollider>());
        }
        else
        {
            rf.lever = false;
        }
    }
}
