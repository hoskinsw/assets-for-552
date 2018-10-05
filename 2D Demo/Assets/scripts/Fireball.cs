using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Attack {

    public float vel;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(vel * direction.x, vel * direction.y);
        transform.up = direction;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(this.gameObject);
    }
}
