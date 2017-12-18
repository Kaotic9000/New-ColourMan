using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private Rigidbody RB;
    public float maxSpeed = 9;
    public float speed = 8;
    public float jumpForce = 30;
    public GameObject corpseprefab;

    public Material Green;
    public Material Blue;
    public Material Red;


    private bool jump;
    private bool isGrounded;
    // Use this for initialization
    void Start() {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (isGrounded)
            {
                RB.AddForce(new Vector3(0, jumpForce, 0) * speed, ForceMode.Impulse);
                isGrounded = false;
            }

        }

        float horizontal = Input.GetAxis("Horizontal");

        /*
		if(Input.GetKeyDown(KeyCode.Space)){
			isGrounded = false;
			jump = true;
		}
        */
        if (RB.velocity.magnitude > maxSpeed) {
            RB.velocity = RB.velocity.normalized * maxSpeed;
        }

        handleMovement(horizontal);

    }

    private void handleMovement(float horizontal) {

        /*
		if(isGrounded && jump){
			isGrounded = false;
			RB.AddForce (new Vector3 (0,jumpForce,0)*speed,ForceMode.Impulse);
			jump = false;
		}
        */

        RB.velocity = new Vector3(horizontal * speed, RB.velocity.y, RB.velocity.z); //x = -1, y = 0;
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            StartCoroutine(Wait());
            isGrounded = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
    

    void OnTriggerEnter(Collider other)
	{
		//removes the star when hit by the player
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.SetActive (false);
		}
		//turns the player green and green walls trigers active
        if (other.gameObject.CompareTag("Green puddle"))
        {
			setPlayerColour (Green,"GreenPlayer");
			setWallTrigger (true,false,false);
        }
		//turns the player red and red walls trigers active
		if (other.gameObject.CompareTag("Red puddle"))
		{
			setPlayerColour (Red,"RedPlayer");
			setWallTrigger (false,true,false);
		}
		//turns the player blue and blue walls trigers active
        if (other.gameObject.CompareTag("Blue puddle"))
        {
			setPlayerColour (Blue,"BluePlayer");
			setWallTrigger (false, false, true);
        }
		//spawns a ragdoll and removes the player object to simulate death
        if (other.gameObject.CompareTag("Kill"))
        {
           Vector3 deathPosition= transform.position;
            Quaternion deathRotation = transform.rotation;
            Material corpsecolour = GameObject.Find("Cube").GetComponent<Renderer>().material;
            Destroy(GameObject.Find("Ragdoll"));
                Instantiate(corpseprefab, deathPosition,deathRotation);
            GameObject.Find("DeadCube").GetComponent<Renderer>().sharedMaterial = corpsecolour;

            
			//TODO: Skal laves på en lidt bedre måde

        }

   //     if (other.gameObject.CompareTag("floor")){
	//		isGrounded = true;
	//	}
	}

	private void setPlayerColour(Material material, string playerTag){
		GameObject.Find("Cube").GetComponent<Renderer>().material = material;
		GameObject.Find("Middle_Spine").tag = playerTag;
	}

	private void setWallTrigger(bool green, bool red, bool blue){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Green wall");
		foreach (GameObject go in gos)
		{
			go.transform.GetComponent<Collider>().isTrigger = green;
		}
		gos = GameObject.FindGameObjectsWithTag("Red wall");
		foreach (GameObject go in gos)
		{
			go.transform.GetComponent<Collider>().isTrigger = red;
		}
		gos = GameObject.FindGameObjectsWithTag("Blue wall");
		foreach (GameObject go in gos)
		{
			go.transform.GetComponent<Collider>().isTrigger = blue;
		}
	}
}
