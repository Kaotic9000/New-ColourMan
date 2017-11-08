using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	float originalX;

	private float floatStrength = 7.25f;

	// Use this for initialization
	void Start () {
		this.originalX = this.transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (originalX + ((float)Mathf.Sin (Time.time) * floatStrength), transform.position.y, transform.position.z);
	}
}