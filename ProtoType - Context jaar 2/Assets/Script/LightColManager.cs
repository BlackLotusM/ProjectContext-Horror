using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColManager : MonoBehaviour
{
    public int level = 3;
    public Light[] lights;

    private void Start()
    {
        StartCoroutine(test());
    }
    private void Update()
    {
        if(level == 3)
        {
            foreach(Light lg in lights)
            {
                lg.color = Color.red;
            }
        }
        else if (level == 2)
        {
            foreach (Light lg in lights)
            {
                lg.color = new Color(1, 0.38f, 0.27f);
            }
        }
        else if (level == 1)
        {
            foreach (Light lg in lights)
            {
                lg.color = Color.yellow;
            }
        }
    }

    IEnumerator test()
    {
        foreach(Light l in lights)
        {
            if (l.gameObject.activeSelf)
            {
                l.enabled = !l.enabled;
            }
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(test());
    }
}
