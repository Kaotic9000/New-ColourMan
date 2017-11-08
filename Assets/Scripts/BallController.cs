using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {


	public Rigidbody RB;

	private float startX;
	private float startY;
	private float x;
	private float y;
	private bool goingR = true;

	void Start(){
		this.startX = transform.position.x;
		this.startY = transform.position.y;
		print ("" + startX + " " + startY);
	}
	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		y = transform.position.y;
		if (x <= startX + 2 && y <= startY + 2 && goingR) {
			RB.AddForce (100, 0, 0);
		} else {
			goingR = false;
		}
			if (x >= startX - 2 && y <= startY +2 && !goingR) {
				RB.AddForce (-100, 0, 0);
			}else{
				goingR = true;
			}
		}

	}

