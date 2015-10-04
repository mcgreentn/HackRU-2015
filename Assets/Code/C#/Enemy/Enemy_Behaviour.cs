using UnityEngine;
using System.Collections;

public class Enemy_Behaviour : MonoBehaviour {

	Rigidbody2D enemyBody;
	Vector3 direction = new Vector3(1,0,0);
	
	void Start () 
	{
		enemyBody = this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(direction * Time.deltaTime); 
	}
	
	// If we hit a left or right wall, invert x direction.
	void OnCollisionEnter2D (Collision2D hit)
	{
		if (hit.gameObject.tag == "Wall") 
		{
			direction.x *= -1;

		}

		if (hit.gameObject.tag == "Enemy") 
		{
			direction.x *= -1;
			
		}
	}


	void steppedOn()
	{

	}
	
}
