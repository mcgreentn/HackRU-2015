using UnityEngine;
using System.Collections;

public class Enemy_Behaviour : MonoBehaviour {

	Rigidbody2D enemyBody;
	
	void Start () 
	{
		enemyBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void move()
	{
		//enemyBody.velocity = Vector2
	}

	void steppedOn()
	{

	}
	
}
