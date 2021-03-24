using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTo : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentTarget = 0;
    public GameObject[] target;
    public BoxCollider[] doors;
    public GameObject player;
    public LookAndMove lm;
    public Camera secondCam;
    public Camera mainCam;
    public bool dead;
    public AudioSource death;

    public Material m1;
    public Material m2;
    void Start()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), doors[i]);
        }

        try
        {
            this.GetComponent<NavMeshAgent>().SetDestination(target[currentTarget].transform.position);
        }
        catch
        {

        }
    }

    bool playOnce = false;

    private void Update()
    {
        if (dead) {
            m1.SetFloat("_Weight", m1.GetFloat("_Weight") + 0.001f);
            m2.SetFloat("_Weight", m2.GetFloat("_Weight") + 0.001f);
            if (!playOnce)
            {
                playOnce = true;
                death.Play();
            }
        }
        if (!dead)
        {
            m1.SetFloat("_Weight", 0);
            m2.SetFloat("_Weight", 0);
            if (Vector3.Distance(this.transform.position, this.GetComponent<NavMeshAgent>().destination) < 0.7f)
            {
                currentTarget++;

                if (currentTarget >= target.Length)
                {
                    this.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
                    lm.canMove = true;
                    mainCam.enabled = true;
                    secondCam.gameObject.SetActive(false);
                }
                else
                {

                    this.GetComponent<NavMeshAgent>().SetDestination(target[currentTarget].transform.position);
                }
            }
        }
    }

    public void killEnemy()
    {
        
        dead = true;
        this.GetComponent<Animator>().enabled = false;
        this.GetComponent<NavMeshAgent>().isStopped = true;
        this.GetComponent<NavMeshAgent>().ResetPath();
    }
}
