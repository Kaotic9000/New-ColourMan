using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
	public Text countText;
	public Text doorText;
	public float rotationSpeed = 1;

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private int count;	

	// Use this for initialization
	void Start () {
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
		count = 3;
		setCountText ();
		doorText.text = "The door is shut";
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;

	}

void setCountText(){
	countText.text = "Stars left: " + count.ToString ();
		if (count >= 1) {
			doorText.text = "The door is open";
		}
}
	void countStarts(){
		count = count - 1;
		setCountText ();

}
}
