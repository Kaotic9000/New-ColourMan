using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float upSpeed = 0.0015f;
<<<<<<< HEAD:New Colour Man/Assets/Scripts/PlayerController.cs

	public Rigidbody RB;

=======
	public float speed = 10;
	public float jumpSpeed = 8;
	public Text countText;
	public Text doorText;
	public Rigidbody MoveBone;
>>>>>>> origin/master:New Colour Man/Assets/Scripts/RagdollController.cs

	private bool isGrounded;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("d"))
		{
			MoveBone.AddForce (Vector3.right * 50*speed);
			//transform.position = transform.position + Vector3.left*Speed ;
		}
		if(Input.GetKey ("a"))
		{
			MoveBone.AddForce (Vector3.left * 50*speed);
			//transform.position = transform.position + Vector3.right*Speed;
		}
		if (Input.GetKey ("space")){

			MoveBone.AddForce (Vector3.up * 50*speed);
			//GetComponent<Rigidbody>().velocity += jumpSpeed * Vector3.up;
		}
	}
	void FixedUpdate ()
	{
		GetComponent<Rigidbody>().AddForce (Vector3.up * upSpeed);

<<<<<<< HEAD:New Colour Man/Assets/Scripts/PlayerController.cs
		if(RB.velocity.magnitude > maxSpeed)
		{
			RB.velocity = RB.velocity.normalized * maxSpeed;
		}
=======
>>>>>>> origin/master:New Colour Man/Assets/Scripts/RagdollController.cs

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
