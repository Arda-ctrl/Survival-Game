using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public AudioClip firesound, deathsound, injuredsound, healtsound;
    public Transform ammoPos;
    public GameObject bullet;
    public GameObject Explosion;
    public Image healthImagine;
    private float healthValue = 100f;
    public randomzombie gControl;
    private AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            GameObject go = Instantiate (bullet,ammoPos.position,ammoPos.rotation)as GameObject;
            GameObject goExplosion = Instantiate(Explosion, ammoPos.position, ammoPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = ammoPos.transform.forward * 10f;
            aSource.PlayOneShot(firesound, 0.5f);
            Destroy(go.gameObject, 2f);
            Destroy(goExplosion.gameObject, 2f);
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            aSource.PlayOneShot(injuredsound, 1f);
            healthValue -= 10f;
            float x = healthValue / 100f;
            healthImagine.fillAmount = x;
            healthImagine.color=Color.Lerp(Color.red,Color.green,x);  
        }
        if(healthValue == 0f)
        {
            aSource.PlayOneShot(deathsound, 1f);
            gControl.finishgame();
        }
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("heart"))
        {
            aSource.PlayOneShot(healtsound,1f);
            healthValue += 10f;
            Destroy(c.gameObject);
            float x = healthValue / 100f;
            healthImagine.fillAmount = x;
            healthImagine.color = Color.Lerp(Color.red, Color.green, x);
        }
    }

}
