using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Barrel;
    public GameObject Fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fire()
    {
        Instantiate(Bullet, Barrel.gameObject.transform.position, this.gameObject.transform.rotation);
        //Instantiate(Fire, Barrel.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
