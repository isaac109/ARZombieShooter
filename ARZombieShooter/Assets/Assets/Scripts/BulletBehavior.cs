using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    public float time = 2;
    public int speed = 40;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward * speed);
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
