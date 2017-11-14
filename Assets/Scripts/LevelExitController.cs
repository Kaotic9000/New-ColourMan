using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExitController : MonoBehaviour {

    Vector3 doorsStartPosition;
    bool exitOpen;
    public GameController controller;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.doorOpen()&& !exitOpen) {
            openDoors();
        }
        if (exitOpen)
        {

        }

	}

    void openDoors()
    {
        //skriv kode der flytter højre og venstre dør fra hinanden til et vist punkt (semi animation)

    }
    private void OnTriggerEnter(Collider other)
    {
        if(exitOpen&& other.gameObject.name == "Middle_Spine")
        {
            controller.levelComplete();
        }
    }
}
