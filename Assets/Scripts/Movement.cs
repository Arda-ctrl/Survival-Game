using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movem : MonoBehaviour
{
    //public AudioClip coin, fall;
    //public GameControl gameC;
    float movement = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // if (gameC.gameActive)
        
            if (Input.GetKey(KeyCode.A))
            {
                // Bloðu +x yönünde hareket ettir
                transform.Translate(Vector3.left * movement * Time.deltaTime);
            }

            // D tuþuna basýldýðýnda
            if (Input.GetKey(KeyCode.D))
            {
                // Bloðu -x yönünde hareket ettir
                transform.Translate(Vector3.right * movement * Time.deltaTime);
            }


            if (Input.GetKey(KeyCode.W))
            {

                transform.Translate(Vector3.forward * movement * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.S))
            {
                // Bloðu -x yönünde hareket ettir
                transform.Translate(Vector3.back * movement * Time.deltaTime);
            }
        

    }
    /*void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("coin"))
        {
            AudioSource.PlayClipAtPoint(coin, transform.position);
            gameC.Coinincrease();
            Destroy(c.gameObject);
        }
        else if (c.gameObject.tag.Equals("enemy"))
        {
            AudioSource.PlayClipAtPoint(fall, transform.position);
            gameC.gameActive = false;

            GetComponent<AudioSource>().Stop();
        }
    }*/
}
