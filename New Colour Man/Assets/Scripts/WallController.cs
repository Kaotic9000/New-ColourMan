﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "GreenPlayer" && !transform.GetComponent<Collider>().isTrigger)
        {
            transform.GetComponent<Collider>().isTrigger = true;
        }
    }
}
