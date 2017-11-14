﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExitController : MonoBehaviour {

    Vector3 doorsStartPosition;
    bool exitOpen;
    public GameController controller;
    public GameObject leftDoor;
    public GameObject rightDoor;
    // Use this for initialization
    void Start () {
        doorsStartPosition = leftDoor.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.doorOpen()&& !exitOpen) {
            exitOpen = true;
        }else if (!doorsOpen())
        {
            leftDoor.transform.localPosition.Set(leftDoor.transform.localPosition.x, leftDoor.transform.localPosition.y + 0.2f, leftDoor.transform.localPosition.z);
            rightDoor.transform.localPosition.Set(rightDoor.transform.localPosition.x, rightDoor.transform.localPosition.y - 0.2f, rightDoor.transform.localPosition.z);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if(exitOpen&& other.gameObject.name == "Middle_Spine")
        {
            controller.levelComplete();
        }
    }

    bool doorsOpen()
    {
        if (leftDoor.transform.localPosition.y == doorsStartPosition.y + 3)
        {
            return true;
        }
        else return false;
    }
}
