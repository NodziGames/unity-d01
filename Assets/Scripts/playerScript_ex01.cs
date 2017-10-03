using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D rb;
	public float movespeed;
	public float jumpstrength;
	public GameObject exit;
	private string nametag = "Thomas";
	public bool on_portal = false;
	private float dst;

	public LayerMask groundLayer;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//Move Left And Right
		if (CompareTag (nametag)) {
			if (Input.GetKey (KeyCode.LeftArrow))
				rb.velocity = new Vector2 (-movespeed, rb.velocity.y);
			else if (Input.GetKey (KeyCode.RightArrow))
				rb.velocity = new Vector2 (movespeed, rb.velocity.y);
			else
				rb.velocity = new Vector2 (0.0f, rb.velocity.y);
			//Jump
			if (Input.GetKey (KeyCode.Space) && isGrounded())
				rb.velocity = new Vector2 (rb.velocity.x, jumpstrength);
		} else
			rb.velocity = new Vector2 (0, rb.velocity.y);

		if (Input.GetKeyDown (KeyCode.Alpha1))
			nametag = "Thomas";
		else if (Input.GetKeyDown (KeyCode.Alpha2))
			nametag = "John";
		else if (Input.GetKeyDown (KeyCode.Alpha3))
			nametag = "Claire";

		
		if (Vector3.Distance (this.transform.position, exit.transform.position) < 0.075f)
			on_portal = true;
		else
			on_portal = false;
	}

	//Check if it's on the ground skrub
	bool isGrounded() {
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 0.15f;

		if (nametag == "Thomas")
			distance = 0.15f;
		if (nametag == "John")
			distance = 0.3f;
		if (nametag == "Claire")
			distance = 0.275f;

		RaycastHit2D hit = Physics2D.Raycast (position, direction, distance, groundLayer);
		if (hit.collider != null) {
			return true;
		}

		return false;
	}
}
