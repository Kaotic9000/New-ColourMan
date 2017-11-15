using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerColliderTest: MonoBehaviour {

	private Rigidbody RB;
    private Renderer rend;
    private Vector3 jump;
    private bool isGrounded;
    public float maxSpeed = 200;
	public float speed = 10;
	public float jumpSpeed = 10;
    public GameObject corpseprefab;



	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();

        rend = GameObject.Find("Cube").GetComponent<Renderer>();

        jump = new Vector3(0.0f, 25.0f+jumpSpeed, 0.0f);


	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKey ("d"))

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
        if (other.gameObject.CompareTag("Puddle"))
        {
            rend.sharedMaterial = other.gameObject.GetComponent<Renderer>().sharedMaterial;

        }
        if (other.gameObject.CompareTag("ColourWall"))
        {
            if (rend.sharedMaterial.name == other.gameObject.GetComponent<Renderer>().sharedMaterial.name)
            {
                Physics.IgnoreCollision(other, gameObject.GetComponent<CapsuleCollider>(), true);
            }
        }

        if (other.gameObject.CompareTag("floor")){
			isGrounded = true;
		}
        if (other.gameObject.CompareTag("Kill"))
        {
            Vector3 deathPosition = transform.position;
            Quaternion deathRotation = transform.rotation;
           Material corpsecolour = rend.sharedMaterial;
            Destroy(GameObject.Find("Ragdoll"));
            Instantiate(corpseprefab, deathPosition, deathRotation);
            GameObject.Find("DeadCube").GetComponent<Renderer>().sharedMaterial = corpsecolour;
            //TODO: Skal laves på en lidt bedre måde

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColourWall"))
        {
            if (rend.sharedMaterial.name == other.gameObject.GetComponent<Renderer>().sharedMaterial.name)
            {
                Physics.IgnoreCollision(other, gameObject.GetComponent<CapsuleCollider>(), false);
            }
        }
    }


}
