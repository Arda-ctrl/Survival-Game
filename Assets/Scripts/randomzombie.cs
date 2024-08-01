using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class randomzombie : MonoBehaviour
{
    public GameObject zombie;
    private float timecount;
    private float formationPeriod = 5f;
    public Text pointText;
    private int point;
    // Start is called before the first frame update
    void Start()
    {
        timecount = formationPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        timecount -= Time.deltaTime;
        if(timecount < 0)
        {
            Vector3 pos = new Vector3(Random.Range(626f, 366f), 18.9f, Random.Range(412f, 662f));
                Instantiate(zombie, pos, Quaternion.identity);
            timecount = formationPeriod;
        }
    }
    public void PointIncrease(int p)
    {
        point += p;
        pointText.text = "" + point;
    }
    public void finishgame()
    {
        PlayerPrefs.SetInt("point", point);
        SceneManager.LoadScene("EndGame");
    }
}
