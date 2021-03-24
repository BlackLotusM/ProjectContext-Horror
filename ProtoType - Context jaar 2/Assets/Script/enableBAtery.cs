using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enableBAtery : MonoBehaviour
{
    public RoomFix rf;
    public GameObject player;
    public GameObject robot;
    public bool close;
    public TextMeshProUGUI text;
    public AudioSource audioS;

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, robot.transform.position) < 2)
        {
            close = true;
        }
        else { close = false; }
    }
    private void OnMouseDown()
    {
        if (close)
        {
            rf.baterij = true;
            audioS.Play();
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        }
    }
}
