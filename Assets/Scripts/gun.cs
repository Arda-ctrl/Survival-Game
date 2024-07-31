using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform ammoPos;
    public GameObject bullet;
    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate (bullet,ammoPos.position,ammoPos.rotation)as GameObject;
            GameObject goExplosion = Instantiate(Explosion, ammoPos.position, ammoPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = ammoPos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(goExplosion.gameObject, 2f);
        }
    }
}
