using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Data
{
    public string Name;
    public Sprite CursorImage;
    public string TriggerTag;
}

public class CursorHandler : MonoBehaviour
{
    public float offset;
    public Image target;
    public Sprite Default;
    public List<Data> Tags;

    // Update is called once per frame
    void Update()
    {
        // Will contain the information of which object the raycast hit
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, offset))
        {
            if (!Tags.Any(n => n.TriggerTag == hit.collider.tag))
            {
                target.sprite = Default;
            }
            else
            {
                if(hit.collider == null)
                {
                    target.sprite = Default;
                }
            }
        }
        else
        {
            target.sprite = Default;
        }


        foreach (Data dat in Tags)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, offset) &&
                    hit.collider.gameObject.CompareTag(dat.TriggerTag))
            {
                target.sprite = dat.CursorImage;
                Debug.LogWarning(dat.TriggerTag);
            }
        }
    }
}
