using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float maxVel;
    private float accel;

    float xVel;
    float yVel;

    private Rigidbody2D rigid;

    private CharacterStats plstats;

	// Use this for initialization
	void Start () {
        plstats = GetComponent<CharacterStats>();
        rigid = GetComponent<Rigidbody2D>();

        maxVel = plstats.maxVel;
        accel = plstats.accel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        xVel = Input.GetAxis("Horizontal");
        yVel = Input.GetAxis("Vertical");

        rigid.velocity = new Vector2(xVel * maxVel, yVel * maxVel);

        Vector2 newUp = new Vector2(xVel, yVel).normalized;

        if(newUp != Vector2.zero)
        {
            float angle1 = Vector2.SignedAngle(Vector2.up, transform.up); //angle to current
            float angle2 = Vector2.SignedAngle(Vector2.up, newUp); //angle to new

            float newAngle = Mathf.MoveTowardsAngle(angle1, angle2, plstats.rotationFactor * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
	}
}
