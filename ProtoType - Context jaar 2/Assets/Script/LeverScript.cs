using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public LookAndMove getval;
    public float oldMouse;

    void OnMouseDown()
    {
        oldMouse = getval.rotationX;
    }

    void OnMouseDrag()
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
