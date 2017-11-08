using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashController : MonoBehaviour {
	float originalY = 0;
	float maxY = 3.69f;
	float y;
	bool ground = true;
	int count = 0;

	// Use this for initialization
	void Start () {
		//this.originalY = this.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		count++;
		if (this.transform.position.y <= maxY && count<1000) {
			y = y+0.01f;
		}
		if (this.transform.position.y >= originalY+0.1f && count > 1000) {
			y = y - 0.1f;
		}
		if (count > 1500) {
			count = 0;
		}
		transform.position = new Vector3 (transform.position.x, y, transform.position.z); 
	}

}
