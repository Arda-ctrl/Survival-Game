using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    private GameObject players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = players.transform.position;
    }
}
