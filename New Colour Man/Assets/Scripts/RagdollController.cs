﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RagdollController : MonoBehaviour {

	public float speed = 10;
	public float maxSpeed = 200;
	public float upSpeed = 0.0015f;
	public Text countText;
	public Text doorText;
	public Rigidbody RB;


	private int count;	
	private bool isGrounded;

	// Use this for initialization
	void Start () {

		count = 3;
		setCountText ();
		doorText.text = "The door is shut";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("d"))
		{
			RB.AddForce (Vector3.right * 50*speed);
			//transform.position = transform.position + Vector3.right*speed ;
		}
		if(Input.GetKey ("a"))
		{
			RB.AddForce (Vector3.left * 50*speed);
			//transform.position = transform.position + Vector3.left*speed;
		}
		if (Input.GetKey ("space")){

			RB.AddForce (Vector3.up * 50*speed);

			//GetComponent<Rigidbody>().velocity += jumpSpeed * Vector3.up;
		}
	}
	void FixedUpdate ()
	{
		GetComponent<Rigidbody>().AddForce (Vector3.up * upSpeed);

		//if(RB.velocity.magnitude > maxSpeed)
		//{
			//RB.velocity = RB.velocity.normalized * maxSpeed;
		//}

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Star"))
		{
			other.gameObject.SetActive (false);
			count = count - 1;
			setCountText ();
		}
	}
	void setCountText(){
		countText.text = "Stars left: " + count.ToString ();
		if (count >= 1) {
			doorText.text = "The door is open";
		}
	}

	void OnCollisionStay(Collision coll){
		isGrounded = true;
	}
	void OnCollisionExit(Collision coll){
		if(isGrounded){
			isGrounded = false;   
		}
	}
}
