using UnityEngine;
using System.Collections;

public class ZombieBehavior : MonoBehaviour {

    public GameObject player;
    public int speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(player.transform);
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * speed);
	}
}
