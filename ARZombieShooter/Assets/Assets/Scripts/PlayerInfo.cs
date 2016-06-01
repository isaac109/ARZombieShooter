using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public float shotsFired = 0;
    public float kills = 0;
    public float lvl = 0;
    public float score = 0;

    public bool start = false;

    public GameObject zombie;
    public int numZombies = 0;


    public Text killsTxt;
    public Text shotsTxt;
    public Text lvlTxt;
    public Text scoreTxt;
    public GameObject gameOverImg;
    public GameObject hud;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (numZombies == 0 && start)
        {
            incramentLvl();
        }
	}

    void incramentLvl()
    {
        lvl++;
        for (int i = 0; i < lvl; i++)
        {
            Vector3 pos = new Vector3(Random.Range(0,15),1,Random.Range(0,15));
            GameObject zom = Instantiate(zombie, pos, Quaternion.identity) as GameObject;
            zom.GetComponent<ZombieBehavior>().player = this.gameObject;
            numZombies++;
        }
    }

    public void incramentShots()
    {
        shotsFired++;
    }
    public void incramentKills()
    {
        kills++;
        numZombies--;
    }
    public void gameOver()
    {
        this.gameObject.SetActive(false);
        killsTxt.text = ((int)kills).ToString() + " Kills";
        shotsTxt.text = ((int)shotsFired).ToString() + " Shots fired";
        lvlTxt.text = ((int)lvl).ToString() + " Waves";
        if (shotsFired != 0)
        {
            score = kills / shotsFired;
        }
        score *= lvl * 10;
        scoreTxt.text = ((int)score).ToString() + " Points";
        gameOverImg.SetActive(true);
        hud.SetActive(false);
    }
}
