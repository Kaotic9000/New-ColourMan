using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashController : MonoBehaviour {

	float speed = 2;
	float start;

	void Start(){
		start = transform.position.y;
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x,  start + Mathf.Sin(Time.time * speed)*1.75f, transform.position.z); 
	}

}
