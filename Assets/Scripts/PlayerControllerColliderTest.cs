﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerColliderTest: MonoBehaviour {

	public Rigidbody RB;
	public float maxSpeed = 200;
	public float speed = 10;
	public float jumpSpeed = 10;

    private Renderer rend;
    public bool isGreen = false;

    public Transform pref;
  


    private Vector3 jump;
	private bool isGrounded;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();

        rend = GameObject.Find("Cube").GetComponent<Renderer>();

        jump = new Vector3(0.0f, 25.0f+jumpSpeed, 0.0f);


	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKey ("d"))

		{
			RB.AddForce (Vector3.right * 50*speed);
			//transform.position = transform.position + Vector3.left*Speed ;
		}
		if(Input.GetKey ("a"))
		{
			RB.AddForce (Vector3.left * 50*speed);
			//transform.position = transform.position + Vector3.right*Speed;
		}
		if (RB.velocity.magnitude > maxSpeed) {
			RB.velocity = RB.velocity.normalized * maxSpeed;
		}
		if (Input.GetKey ("space")){
			//RB.AddForce (Vector3.up * jumpSpeed);
			if (isGrounded) {
				RB.AddForce (jump * jumpSpeed, ForceMode.Impulse);
			}
			isGrounded = false;


		}
	}
	void FixedUpdate ()


	{

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.SetActive (false);
		}
        if (other.gameObject.CompareTag("Puddle"))
        {
            rend.sharedMaterial = other.gameObject.GetComponent<Renderer>().sharedMaterial;

        }
        if (other.gameObject.CompareTag("ColourWall"))
        {
            if (rend.sharedMaterial.name == other.gameObject.GetComponent<Renderer>().sharedMaterial.name)
            {
                Physics.IgnoreCollision(other, gameObject.GetComponent<CapsuleCollider>(), true);
            }
        }

        if (other.gameObject.CompareTag("floor")){
			isGrounded = true;
		}
	}
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColourWall"))
        {
            if (rend.sharedMaterial.name == other.gameObject.GetComponent<Renderer>().sharedMaterial.name)
            {
                Physics.IgnoreCollision(other, gameObject.GetComponent<CapsuleCollider>(), false);
            }
        }
    }


}
