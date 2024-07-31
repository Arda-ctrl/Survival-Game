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
     
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = players.transform.position;
        distencee = Vector3.Distance(transform.position, players.transform.position);
        if(distencee < 3f)
        {
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("bullet"))
        {
            Debug.Log("vurdun");
            zombiehealth--;
            if (zombiehealth == 1)
            {
                Instantiate(heart, transform.position,Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
