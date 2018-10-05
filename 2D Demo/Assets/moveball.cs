using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1"))
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            transform.position = newPos;
        }
	}
}
