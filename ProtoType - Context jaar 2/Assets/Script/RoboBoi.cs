using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoboBoi : MonoBehaviour
{
    public GameObject player;
    public BoxCollider[] doors;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), doors[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 1.8f)
        {
            this.GetComponent<NavMeshAgent>().ResetPath();
        }
        else
        {
            this.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
        this.transform.LookAt(player.transform.position);
    }
}
