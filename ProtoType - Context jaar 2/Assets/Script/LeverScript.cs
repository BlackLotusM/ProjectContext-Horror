using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject player;

    private float deltaY;
    private float deltaY2;
    private float force;

    public onclick obj1;
    public onclick obj2;

    public Light light;

    public float forceModifier;
    public float rotation;
    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 6.2f)
        {
            deltaY = (Camera.main.transform.position.y + Camera.main.transform.forward.y);
        }
    }

    private void Update()
    {
        if (rotation >= 80)
        {
            obj1.setActive = true;
            obj2.setActive = true;

            light.intensity = 1;
        }
        else
        {
            obj1.setActive = false;
            obj2.setActive = false;

            light.intensity = 0;
        }
    }
    private void OnMouseDrag()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 6.01f)
        {
            deltaY2 = (Camera.main.transform.position.y + Camera.main.transform.forward.y);
            force = (deltaY - deltaY2) * forceModifier;

            if (force > 0)
            {
                if (rotation >= 90)
                {
                    Debug.Log("test1");
                }
                else
                {
                    rotation += force;
                    transform.eulerAngles = new Vector3(
                            rotation,
                            transform.eulerAngles.y,
                            transform.eulerAngles.z
                        );
                }
            }
            else
            {
                if (force < 0)
                {
                    if (rotation <= 0)
                    {
                        Debug.Log("test2");
                    }
                    else
                    {
                        rotation += force;
                        transform.eulerAngles = new Vector3(
                            rotation,
                            transform.eulerAngles.y,
                            transform.eulerAngles.z
                        );
                    }
                }
            }

            if (rotation < 0)
            {
                rotation = 0;
                transform.eulerAngles = new Vector3(
                            rotation,
                            transform.eulerAngles.y,
                            transform.eulerAngles.z
                        );
            }

            if (rotation > 90)
            {
                rotation = 90;
                transform.eulerAngles = new Vector3(
                            rotation,
                            transform.eulerAngles.y,
                            transform.eulerAngles.z
                        );
            }
        }
    }
}
