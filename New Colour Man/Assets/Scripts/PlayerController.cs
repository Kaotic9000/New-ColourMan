using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody RB;
	public float maxSpeed = 200;
	public float speed = 10;
	public float jumpSpeed = 10;

    public bool isGreen = false;

    public Transform pref;

    public Material Green;


    private Vector3 jump;
	private bool isGrounded;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		jump = new Vector3(0.0f, 25.0f+jumpSpeed, 0.0f);

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

        if (other.gameObject.CompareTag("Green puddle"))
        {
            GameObject.Find("Cube").GetComponent<Renderer>().material = Green;
            GameObject.Find("Middle_Spine").tag = "GreenPlayer";
        }

        if (other.gameObject.CompareTag("floor")){
			isGrounded = true;
		}
	}
}
