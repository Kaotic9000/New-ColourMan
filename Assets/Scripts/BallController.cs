using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {


	public Rigidbody RB;
	public float height = 2;
	public float force = 100;

	private float startX;
	private float startY;
	private float x;
	private float y;
	private bool goingR = true;
	private int count = 0;

	void Start(){
		this.startX = transform.position.x;
		this.startY = transform.position.y;
		print ("" + startX + " " + startY);
	}
	// Update is called once per frame
	void Update () {
		if (count > 100 && force > 3) {
			force = force - 0.01f;
			//print ("Force: "+force);
		}
		count++;
		x = transform.position.x;
		y = transform.position.y;
		if (x <= startX + 2 && y <= startY + height && goingR) {
			RB.AddForce (force, 0, 0);
		} else {
			goingR = false;
		}
			if (x >= startX - 2 && y <= startY +height && !goingR) {
				RB.AddForce (-force, 0, 0);
			}else{
				goingR = true;
			}
		}
	}