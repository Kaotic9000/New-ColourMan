using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody RB;
	public float maxSpeed = 200;
	public float speed = 10;
	public float jumpSpeed = 10;
	public GameObject prefab;


    public bool isGreen = false;
    
    public Material Green;
    public Material Blue;
    public Material Red;


    private Vector3 jump;
	private bool isGrounded;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		jump = new Vector3(0.0f, 25.0f+jumpSpeed, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("d"))
		{
			RB.AddForce (Vector3.right * 50*speed);
			//transform.position = transform.position + Vector3.left*Speed ;
		}
		if(Input.GetKey ("a"))
		{
			RB.AddForce (Vector3.left * 50*speed);
			//transform.position = transform.position + Vector3.right*Speed;
		}
		if (RB.velocity.magnitude > maxSpeed) {
			RB.velocity = RB.velocity.normalized * maxSpeed;
		}
		if (Input.GetKey ("space")){
			//RB.AddForce (Vector3.up * jumpSpeed);
			if (isGrounded) {
				RB.AddForce (jump * jumpSpeed, ForceMode.Impulse);
			}
			isGrounded = false;

		}
	}
	void FixedUpdate ()


	{

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Star")) {
			other.gameObject.SetActive (false);
		}

        if (other.gameObject.CompareTag("Green puddle"))
        {
            GameObject.Find("Cube").GetComponent<Renderer>().material = Green;
            GameObject.Find("Middle_Spine").tag = "GreenPlayer";

            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Green wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = true;
            }
            gos = GameObject.FindGameObjectsWithTag("Red wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = false;
            }
            gos = GameObject.FindGameObjectsWithTag("Blue wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = false;
            }
        }

        if (other.gameObject.CompareTag("Blue puddle"))
        {
            GameObject.Find("Cube").GetComponent<Renderer>().material = Blue;
            GameObject.Find("Middle_Spine").tag = "BluePlayer";

            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Blue wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = true;
            }
            gos = GameObject.FindGameObjectsWithTag("Green wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = false;
            }
            gos = GameObject.FindGameObjectsWithTag("Red wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = false;
            }
        }

        if (other.gameObject.CompareTag("Red puddle"))
        {
            GameObject.Find("Cube").GetComponent<Renderer>().material = Red;
            GameObject.Find("Middle_Spine").tag = "RedPlayer";

            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Red wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = true;
            }
            gos = GameObject.FindGameObjectsWithTag("Blue wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = false;
            }
            gos = GameObject.FindGameObjectsWithTag("Green wall");
            foreach (GameObject go in gos)
            {
                go.transform.GetComponent<Collider>().isTrigger = false;
            }
        }

        if (other.gameObject.CompareTag("Kill"))
        {

            Destroy(GameObject.Find("Ragdoll"));
			prefab = Instantiate (prefab,transform.position,Quaternion.Euler(0,90,0)) as GameObject;


			//TODO: mangler en krop som falder over


        }

        if (other.gameObject.CompareTag("floor")){
			isGrounded = true;
		}
	}
}
