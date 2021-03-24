using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuse : MonoBehaviour
{
    public fuseManager fm;
    public GameObject fuseDisplay;
    private void OnMouseDown()
    {
        fm.fixedFuse++;
        fuseDisplay.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
