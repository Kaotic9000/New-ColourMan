using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Ragdoll(Clone)") == null)
        {
            Instantiate(prefab, this.transform);
           
        }
	}
}
