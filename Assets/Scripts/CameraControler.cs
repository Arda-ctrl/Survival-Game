using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //public GameControl gameC;
    float sensitive = 5f;
    float softy = 2f;

    Vector2 gecisPos;
    Vector2 camPos;
    GameObject player;
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       // if (gameC.gameActive)
        
            Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            farePos = Vector2.Scale(farePos, new Vector2(sensitive * softy, sensitive * softy));
            gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / softy);
            gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / softy);
            camPos += gecisPos;

            camPos.y = Mathf.Clamp(camPos.y, -90f, 90f);
            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(camPos.x, player.transform.up);
        
    }
}
