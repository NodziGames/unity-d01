using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour {

	// Use this for initialization
	public GameObject thomas;
	public GameObject john;
	public GameObject claire;
	public string nextlevel;

	private int following = 1;
	private Vector3 camera_goal;
	private Quaternion camera_rotation = Quaternion.Euler(0, 0, 0);

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1))
			following = 1;
		else if (Input.GetKeyDown (KeyCode.Alpha2))
			following = 2;
		else if (Input.GetKeyDown (KeyCode.Alpha3))
			following = 3;
		else if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		switch (following)
		{
		case 1:
			camera_goal = new Vector3 (thomas.transform.position.x, thomas.transform.position.y, -10.0f);
			camera_rotation = Quaternion.Euler(0, 0, GameObject.FindGameObjectWithTag ("Thomas").GetComponent<playerScript_ex01> ().rb.velocity.x * 2.0f);
			break;
		case 2:
			camera_goal = new Vector3 (john.transform.position.x, john.transform.position.y, -10.0f);
			camera_rotation = Quaternion.Euler(0, 0, GameObject.FindGameObjectWithTag ("John").GetComponent<playerScript_ex01> ().rb.velocity.x * 2.0f);
			break;
		case 3:
			camera_goal = new Vector3 (claire.transform.position.x, claire.transform.position.y, -10.0f);
			camera_rotation = Quaternion.Euler(0, 0, GameObject.FindGameObjectWithTag ("Claire").GetComponent<playerScript_ex01> ().rb.velocity.x * 2.0f);
			break;
		}

		transform.position = Vector3.Lerp (transform.position, camera_goal, 0.1f);
		transform.rotation = Quaternion.Lerp(transform.rotation, camera_rotation, 0.1f);

		if (GameObject.FindGameObjectWithTag ("Thomas").GetComponent<playerScript_ex01> ().on_portal && GameObject.FindGameObjectWithTag ("John").GetComponent<playerScript_ex01> ().on_portal && GameObject.FindGameObjectWithTag ("Claire").GetComponent<playerScript_ex01> ().on_portal)
			SceneManager.LoadScene (nextlevel);
	}
}
