using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	private GameObject player;       //Public variable to store a reference to the player game object
	public Text countText;
	public Text doorText;
	public float rotationSpeed = 1;

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private int numberofstars;	

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
		numberofstars = GameObject.FindGameObjectsWithTag("Star").Length; ; ;
		updateText ();
		doorText.text = "The door is shut";
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        player = GameObject.FindGameObjectWithTag("Player"); 
        transform.position = player.transform.position + offset;
        updateText();
        
	}


    void updateText(){
        int count = countStarts();
	countText.text = "Stars left: " + count;
		if (numberofstars > count) {
			doorText.text = "The door is open";
		}
}
	int countStarts(){
        return GameObject.FindGameObjectsWithTag("Star").Length; ;

}
}
