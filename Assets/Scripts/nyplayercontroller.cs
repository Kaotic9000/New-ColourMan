﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyplayercontroller : MonoBehaviour {


	private Rigidbody RB;
	public float maxSpeed = 200;
	public float speed = 10;
	public float jumpForce = 10;
	public GameObject corpseprefab;

	public Material Green;
	public Material Blue;
	public Material Red;


	private bool jump;
	private bool isGrounded;
	[SerializeField]
	private GameObject[] groundPoints;

	[SerializeField]
	private float groundRadius;

	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		//jump = new Vector3(0.0f, 25.0f+jumpSpeed, 0.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal");

		if(Input.GetKeyDown(KeyCode.Space)){
			isGrounded = false;
			jump = true;
		}




		handleMovement (horizontal);
		/*
        if (Input.GetKey ("d"))
		{
                RB.AddForce(Vector3.right * 50 * speed);
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
		*/
	}
	/*
	private bool IsGrounded(){
		if (RB.velocity.y <= 0) {
			if () {
				return true;
			}
		}
		return false;
	}
*/
	private void handleMovement(float horizontal){

		if(isGrounded && jump){
			isGrounded = false;
			RB.AddForce (new Vector3 (0,jumpForce,0)*speed,ForceMode.Impulse);
		}

		RB.velocity = new Vector3 (horizontal*speed, RB.velocity.y, RB.velocity.z); //x = -1, y = 0;
	}
	/*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("floor")) isGrounded = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("floor")) isGrounded = false;
    }
*/
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("floor")){
			isGrounded = true;
		}
		//removes the star when hit by the player
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.SetActive (false);
		}
		//turns the player green and green walls trigers active
		if (other.gameObject.CompareTag("Green puddle"))
		{
			setPlayerColour (Green,"GreenPlayer");
			setWallTrigger (true,false,false);
		}
		//turns the player red and red walls trigers active
		if (other.gameObject.CompareTag("Red puddle"))
		{
			setPlayerColour (Red,"RedPlayer");
			setWallTrigger (false,true,false);
		}
		//turns the player blue and blue walls trigers active
		if (other.gameObject.CompareTag("Blue puddle"))
		{
			setPlayerColour (Blue,"BluePlayer");
			setWallTrigger (false, false, true);
		}
		//spawns a ragdoll and removes the player object to simulate death
		if (other.gameObject.CompareTag("Kill"))
		{
			Vector3 deathPosition= transform.position;
			Quaternion deathRotation = transform.rotation;
			Material corpsecolour = GameObject.Find("Cube").GetComponent<Renderer>().material;
			Destroy(GameObject.Find("Ragdoll"));
			Instantiate(corpseprefab, deathPosition,deathRotation);
			GameObject.Find("DeadCube").GetComponent<Renderer>().sharedMaterial = corpsecolour;


			//TODO: Skal laves på en lidt bedre måde

		}

		//     if (other.gameObject.CompareTag("floor")){
		//		isGrounded = true;
		//	}
	}

	private void setPlayerColour(Material material, string playerTag){
		GameObject.Find("Cube").GetComponent<Renderer>().material = material;
		GameObject.Find("Middle_Spine").tag = playerTag;
	}

	private void setWallTrigger(bool green, bool red, bool blue){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Green wall");
		foreach (GameObject go in gos)
		{
			go.transform.GetComponent<Collider>().isTrigger = green;
		}
		gos = GameObject.FindGameObjectsWithTag("Red wall");
		foreach (GameObject go in gos)
		{
			go.transform.GetComponent<Collider>().isTrigger = red;
		}
		gos = GameObject.FindGameObjectsWithTag("Blue wall");
		foreach (GameObject go in gos)
		{
			go.transform.GetComponent<Collider>().isTrigger = blue;
		}
	}
}
