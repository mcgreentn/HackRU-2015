using UnityEngine;
using System.Collections;

public class Enemy_Behaviour : MonoBehaviour {

	Rigidbody2D enemyBody;
	bool moveXFlag = true;
	
	void Start () 
	{
		enemyBody = this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		move ();
	}

	void  OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Jump_Platform") {
			moveXFlag = !moveXFlag;
		}

		if (col.gameObject.name == "Sphere")
			Destroy (col.gameObject);
	}

	void move()
	{
		if (moveXFlag == true)
			enemyBody.velocity = new Vector2(1.0f,0.0f);
		else
			enemyBody.velocity = new Vector2(-1.0f,0.0f);
	}

	void steppedOn()
	{

	}
	
}
