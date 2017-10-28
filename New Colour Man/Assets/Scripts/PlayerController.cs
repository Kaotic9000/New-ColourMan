using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float upSpeed = 0.0015f;
	public float Speed = 0.0015f;
	public float jumpSpeed = 8;
	public Text countText;
	public Text doorText;

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
		if(Input.GetKey ("left"))
		{
			transform.position = transform.position + Vector3.left*Speed ;
		}
		if(Input.GetKey ("right"))
		{
			transform.position = transform.position + Vector3.right*Speed;
		}
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded){

			GetComponent<Rigidbody>().velocity += jumpSpeed * Vector3.up;
		}
	}
	void FixedUpdate ()
	{
		GetComponent<Rigidbody>().AddForce (Vector3.up * upSpeed);


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
