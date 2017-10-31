using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody RB;
	public float maxSpeed = 200;
	public float speed = 10;
	public float jumpSpeed = 10;

	private bool isGrounded;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("d"))
		{
			RB.AddForce (Vector3.right * 50*speed);
			//transform.position = transform.position + Vector3.left*Speed ;
		}
		if(Input.GetKey ("a"))
		{
			RB.AddForce (Vector3.left * 50*speed);
			//transform.position = transform.position + Vector3.right*Speed;
		}
		if (Input.GetKey ("space")){
			RB.AddForce (Vector3.up * jumpSpeed);
		}
	}
	void FixedUpdate ()
	{

		if(RB.velocity.magnitude > maxSpeed)
		{
			RB.velocity = RB.velocity.normalized * maxSpeed;
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.SetActive (false);
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
