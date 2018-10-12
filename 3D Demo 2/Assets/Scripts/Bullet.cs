using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = .1f;

    Vector3 prevPos;
    GameObject playerPos;
    Vector3 dir;

	// Use this for initialization
	void Awake () {
        Destroy(this.gameObject, 5f);
        prevPos = transform.position;
        playerPos = GameObject.Find("character");
        dir = playerPos.transform.right;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        prevPos = transform.position;

        transform.Translate(dir * (speed * Time.deltaTime));

        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPos, 
            (transform.position - prevPos).normalized), (transform.position - prevPos).magnitude);

        for(int i = 0; i < hits.Length; i++)
        {
            if(hits[i].collider.gameObject.name.Equals("Enemy"))
            {
                //reduce health
                hits[i].collider.gameObject.GetComponent<Enemy>().health--;
            }
            Destroy(this.gameObject);
        }
	}
}
