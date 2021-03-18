using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public BoxCollider[] doors;

    void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), doors[i]);
        }

        try
        {
            this.GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        }
        catch
        {

        }
    }

}
