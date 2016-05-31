using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public Damage damType = Damage.NONE;

    public enum Damage{
        BULLET,
        ZOMBIE,
        NONE
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit");

        if (other.collider.tag == "zombie" && damType == Damage.ZOMBIE)
        {
            this.GetComponent<PlayerInfo>().gameOver();
        }
        else if (other.collider.tag == "bullet" && damType == Damage.BULLET)
        {
            this.GetComponent<ZombieBehavior>().player.GetComponent<PlayerInfo>().incramentKills();
            Destroy(this.gameObject);
        }
    }

}
