using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuseManager : MonoBehaviour
{
    public RoomFix rf;
    public int fixedFuse;

    private void Update()
    {
        if(fixedFuse >= 3)
        {
            rf.fuse = true;
        }
    }
}
