using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float mouseSpeed = 3;
    float X, Y;
    float velX, velY;

    public float maxVel;

    Rigidbody rigid;

    bool isFire1 = true;
    public GameObject fire1, fire2;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        X = Input.GetAxis("Mouse X") * mouseSpeed;
        Y = Input.GetAxis("Mouse Y") * mouseSpeed;

        transform.Rotate(0, X, 0);

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");

        Vector3 forwardVel = transform.forward * maxVel * -velX;
        Vector3 horizontalVel = transform.right * maxVel * velY;
        Vector3 sumVel = forwardVel + horizontalVel;
        sumVel.y = rigid.velocity.y;

        rigid.velocity = sumVel;

        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
	}

    void Fire()
    {
        Vector3 bulletPos;
        if (isFire1)
            bulletPos = fire1.transform.position;
        else
            bulletPos = fire2.transform.position;
        //bulletPos = isFire1?fire1.transform.position:fire2.transform.position;
        GameObject b = Instantiate(bullet, bulletPos, new Quaternion());

        isFire1 = !isFire1;
    }
}
