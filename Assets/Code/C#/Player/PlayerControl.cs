using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {
    public LayerMask playerMask;
    public float speed = 10, jumpVelocity = 10;
    Transform myTrans;
    Transform tagGround;
    Rigidbody2D myBody;

	//End game flag
	bool gameEndFlag = false;

    public bool isGrounded = false;
    public bool isMobile = false;

	//Start position
	private Vector3 startPoint = new Vector3(-1.5f,1.677f,0.0f);
	
	//End position
	private float endPoint = 12.5f;

	void Start ()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            //we are on a desktop device, so don't use touch
            isMobile = true;
        }
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
	}
	
	
	void FixedUpdate ()
    {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        if (isMobile == false)
        {
            Move(Input.GetAxisRaw("Horizontal"));
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            Move(CrossPlatformInputManager.GetAxis("Horizontal"));
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
		/*if (gameObject.transform.position.x == endPoint) {
			gameEndFlag = true;
		}*/
        
	}

	/*void OnCollisionEnter (Collision hit)
	{
		var tag = hit.gameObject.tag; 
		if (tag == "Enemy") 
		{
			hit.collider.gameObject.SetActive (false);

			
		}*/
	//}
}
