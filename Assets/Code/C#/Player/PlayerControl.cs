using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public LayerMask playerMask;
    public float speed = 10, jumpVelocity = 10;
    Transform myTrans;
    Transform tagGround;
    Rigidbody2D myBody;

    public bool isGrounded = false;

	// Use this for initialization
	void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
	}
	
	
	void FixedUpdate ()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        Move(Input.GetAxisRaw("Horizontal"));
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
	}
    
    //Allows player to move
    public void Move(float horizontal_input)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontal_input * speed;
        myBody.velocity = moveVel;
    }

    //Allows player to Jump
    public void Jump()
    {
        if (isGrounded)
        {
            myBody.velocity += jumpVelocity * Vector2.up;
        }
    }

}
