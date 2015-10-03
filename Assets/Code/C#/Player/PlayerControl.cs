using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public LayerMask playerMask;
    public float speed = 10, jumpVelocity = 10;
    Transform myTrans;
    Transform tagGround;
    Rigidbody2D myBody;

	//End game flag
	bool gameEndFlag = false;

    public bool isGrounded = false;

	//Start position
	private Vector3 startPoint = new Vector3(-1.5f,1.677f,0.0f);
	
	//End position
	private float endPoint = 12.5f;

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
    
	void Update()
	{
		if (gameObject.transform.position.y < -10) {
			outOfBonds ();
		}
		levelCompletition ();
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

	public void outOfBonds()
	{
		gameObject.transform.position = startPoint;
		myBody.velocity = new Vector2 (0.0f,0.0f);
	}
	
	public void levelCompletition()
	{
		if (gameObject.transform.position.x == endPoint) {
			gameEndFlag = true;
		}
	}
}
