using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public float shotsFired = 0;
    public float kills = 0;
    public float lvl = 0;
    public float score = 0;

    public GameObject zombie;
    public int numZombies = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (numZombies == 0)
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
    }
}
