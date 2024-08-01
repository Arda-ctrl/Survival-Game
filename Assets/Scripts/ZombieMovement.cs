using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    private GameObject players;
    private int zombiehealth = 3;
    private float distencee;
    public GameObject heart;
    private randomzombie gControl;
    private int zombiedeathpoint = 2;
    private AudioSource aSource;
    private bool zombiedeathh = false;
     
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        //aSource.pitch = 2.0f;
        players = GameObject.Find("player");
        gControl = GameObject.Find("script").GetComponent<randomzombie>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = players.transform.position;
        distencee = Vector3.Distance(transform.position, players.transform.position);
        if(distencee < 2f)
        {
            if(!aSource.isPlaying)
                aSource.Play();
            if(!zombiedeathh)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("bullet"))
        {
            Debug.Log("vurdun");
            zombiehealth--;
            if (zombiehealth == 0)
            {
                zombiedeathh=true;
                gControl.PointIncrease(zombiedeathpoint);
                Instantiate(heart, transform.position,Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
