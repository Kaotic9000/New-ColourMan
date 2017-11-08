using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {
    private Renderer rend;


    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
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
