using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableBAtery : MonoBehaviour
{
    private void OnMouseDown()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
