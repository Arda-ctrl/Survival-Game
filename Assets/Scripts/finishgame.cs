using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishgame : MonoBehaviour
{
    public Text point;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        point.text = "Your Point:" + PlayerPrefs.GetInt("point");
    }

    // Update is called once per frame
    public void AgainPlay()
    {
        SceneManager.LoadScene("StartGame");
    }
}
