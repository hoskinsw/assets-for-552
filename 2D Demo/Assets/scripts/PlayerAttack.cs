using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject fireball;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            GameObject attackHolder = Instantiate(fireball, transform.position, new Quaternion());
            attackHolder.GetComponent<Attack>().direction = transform.up;
        }
	}
}
