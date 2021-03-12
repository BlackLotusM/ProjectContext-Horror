using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouse : MonoBehaviour
{
    public bool fuse;
    public GameObject player;
    private void OnMouseDown()
    {
        if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), new Vector2(this.transform.position.x, this.transform.position.z)) < 2)
        {
            fuse = true;
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        } 
    }

    private void Update()
    {
        if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), new Vector2(this.transform.position.x, this.transform.position.z)) < 2)
        {
            this.tag = "Clickable";
        }
        else
        {
            this.tag = "Untagged";
        }
    }
}
