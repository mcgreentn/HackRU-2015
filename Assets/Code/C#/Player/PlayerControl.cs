using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour {
    public LayerMask playerMask;
	public float speed = 10, jumpVelocity = 10; 
    Transform myTrans;
    Transform tagGround;
    Rigidbody2D myBody;

    public bool isGrounded = false;
    public bool isMobile = false;

	//Start position
	private Vector3 startPoint = new Vector3(-1.5f,1.677f,0.0f);

    //End position
    public Vector3 endPoint;

	//Water power up
	private bool waterTimerFlag = false;
	private float waterTimeCounter = 0.0f;
	private float waterSpeed = 1;

	//Honey power up
	private bool honeyTimerFlag = false;
	private float honeyTimeCounter = 0.0f;

	//Pill power up
	private bool pillTimerFlag = false;
	private float pillTimeCounter = 0.0f;
	private float pillJump = 1.0f;

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
			outOfBounds ();
		}
		waterEffect ();
		honeyEffect ();
		pillEffect ();
	}

    //Allows player to move
    public void Move(float horizontal_input)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontal_input * speed * waterSpeed;
        myBody.velocity = moveVel;
    }

    //Allows player to Jump
    public void Jump()
    {
        if (isGrounded)
        {
            myBody.velocity += jumpVelocity * Vector2.up * pillJump;
        }
    }

	public void outOfBounds()
	{
		gameObject.transform.position = startPoint;
		myBody.velocity = new Vector2 (0.0f,0.0f);
	}

	void OnCollisionEnter2D (Collision2D hit)
	{
        if (hit.gameObject.tag == "Enemy") {
			if ((gameObject.transform.position.y > hit.gameObject.transform.position.y) || (honeyTimerFlag == true)) {
				hit.gameObject.SetActive (false);
				Destroy (hit.gameObject);
			} else {
				gameObject.transform.position = startPoint;
			}

		} else if (hit.gameObject.name.Equals ("ExitDoor")) {
			levelCompletition ();
		} else if (hit.gameObject.tag == "Water") { //touches water powerup
			//activate timer and powerup effect
			waterTimerFlag = true;
			//destroys object
			hit.gameObject.SetActive (false);
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Honey") { //touches water powerup
			//activate timer and powerup effect
			honeyTimerFlag = true;
			//destroys object
			hit.gameObject.SetActive (false);
			Destroy (hit.gameObject);
		} else if (hit.gameObject.tag == "Pill") {
			//activate timer and powerup effect
			pillTimerFlag = true;

			//destroys object
			hit.gameObject.SetActive (false);
			Destroy (hit.gameObject);
		}

    }


	void waterEffect()
	{
		if (waterTimerFlag == true)
			waterTimeCounter += Time.deltaTime;

		if (waterTimeCounter >= 10f || waterTimerFlag == false) {
			waterTimerFlag = false;
			waterTimeCounter = 0.0f;
			waterSpeed = 1.0f;
		}
		else
		{
			waterSpeed = 2.5f;
		}
	}

	void honeyEffect()
	{
		if (honeyTimerFlag == true)
			honeyTimeCounter += Time.deltaTime;
		
		if (honeyTimeCounter >= 10f || honeyTimerFlag == false) {
			honeyTimerFlag = false;
			honeyTimeCounter = 0.0f;
		}
	}

	void pillEffect()
	{
		if (pillTimerFlag == true)
			pillTimeCounter += Time.deltaTime;

		if (pillTimeCounter >= 10f || pillTimerFlag == false) {
			pillTimerFlag = false;
			pillTimeCounter = 0.0f;
			pillJump = 1.0f;
		} 
		else {
			pillJump = 2.5f;
		}
	}
	
	public void levelCompletition()
	{
        Application.LoadLevel("stages");	       
	}


	//}
}
