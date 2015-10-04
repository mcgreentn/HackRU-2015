using UnityEngine;
using System.Collections;

public class Enemy_Behaviour : MonoBehaviour {

	Rigidbody2D enemyBody;
	//bool moveXFlag = true;
	Vector3 direction = new Vector3(1,0,0);
	//float enemyBox = f;
	
	void Start () 
	{
		enemyBody = this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(direction * Time.deltaTime); 
	}

	/*void  OnControllerColliderHit ( ControllerColliderHit hit )
	{

		if (hit.collider.gameObject.CompareTag ("Wall") )
		{
			moveXFlag = !moveXFlag;
			enemyBody.velocity = -enemyBody.velocity;
		}

		/*if (col.gameObject.name == "Jump_Platform") {
			moveXFlag = !moveXFlag;
		}

		if (col.gameObject.name == "Sphere")
			Destroy (col.gameObject);
	}*/

	// If we hit a left or right wall, invert x direction.
	void OnCollisionEnter (Collision hit)
	{
		if (hit.gameObject.tag == "Wall") 
		{
			//gameObject.transform.position = (gameObject.transform.position.x - 0.5f, enemyBody.transform.position.y, 
			                               // enemyBody.transform.position.z);
			gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
			                                            gameObject.transform.position.z);
			//gameObject.transform.position.x = hit.gameObject.transform.position.y - 0.5f - enemyBox;
			direction.x *= -1;

		}
	}
	
	/*void move()
	{
		if (moveXFlag == true)
			enemyBody.velocity = new Vector2 (1.0f, 0.0f);
		else {
			enemyBody.velocity = -enemyBody.velocity;

		}
	}*/
	

	void steppedOn()
	{

	}
	
}
