using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public Transform ammoPos;
    public GameObject bullet;
    public GameObject Explosion;
    public Image healthImagine;
    private float healthValue = 100f;
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
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            healthValue -= 10f;
            float x = healthValue / 100f;
            healthImagine.fillAmount = x;
            healthImagine.color=Color.Lerp(Color.red,Color.green,x);    
        }
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("heart"))
        {
            healthValue += 10f;
            Destroy(c.gameObject);
            float x = healthValue / 100f;
            healthImagine.fillAmount = x;
            healthImagine.color = Color.Lerp(Color.red, Color.green, x);
        }
    }

}
