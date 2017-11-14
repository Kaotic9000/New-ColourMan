using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	private GameObject player;       //Public variable to store a reference to the player game object
	public float rotationSpeed = 1;
    public int cameraheight=7;

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	

	// Use this for initialization
	void Start () {
		findGO ();
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		//print("" + offset.x + " " + offset.y + " " + offset.z);
		offset = new Vector3(0, cameraheight, transform.position.z+player.transform.position.z);

	}

	// Update is called once per frame
	void LateUpdate () {
		findGO ();
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			transform.position = player.transform.position + offset; 
	}

	void findGO(){
		player = GameObject.Find("Middle_Spine");
	}



}
