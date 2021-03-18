using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuse : MonoBehaviour
{
    public GameObject fuseDisplay;
    private void OnMouseDown()
    {
        fuseDisplay.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
