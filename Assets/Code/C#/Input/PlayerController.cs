using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	//private float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float horizontalMov = Input.GetAxis ("Horizontal");
		float verticalMov = Input.GetAxis ("Vertical");

		Vector3 moviment = new Vector3 (horizontalMov, verticalMov, 0.0f);

		rb.AddForce (moviment);
	}
}
