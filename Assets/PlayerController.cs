using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	Animator animator;
	[HideInInspector] 
	public bool isFacingRight = true;			// Is the player sprite facing the righthand side of the screen?
	[HideInInspector]
	public bool isGrounded = false;				// Is the player touching ground?
	public bool jump;
	public float maxSpeed;				// The fastest the player can travel in the x axis.
	public float jumpForce = 650.0f;			// Amount of force added when the player jumps.
	public float move;
	public Transform groundCheck;				// GameObject transform used for ground check
	public LayerMask groundLayers;				// Mask denoting layers that count as "ground"

	private float groundCheckRadius = 0.2f;		// Distance from transform center that we check for ground

	// Use this for initialization
	void Start () 
	{
//		Animator = GetComponent<Animator> ();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			animator.SetBool ("Hurt", true);
		}

		// Check for player input
		// Is the player pressing jump?  Are they on the ground?
		if(Input.GetButtonDown("Jump"))
		{
			// Is the player on the ground?
			if(isGrounded == true)
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);		// Zero out vertical velocity to prevent increased jump height when going up an incline
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));					// Apply jump force value
				animator.SetBool("JumpB", true);
				//animator.SetBool("JumpB", true);
			}
			else
			{
				Debug.Log("Jump pressed while not grounded");
			}
		if(isGrounded == false){
				animator.SetBool("JumpB", true);
			}
		}
	}

	// FixedUpdate is called at a fixed rate
	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle						// Test if the player is touching ground
			(groundCheck.position, groundCheckRadius, groundLayers);
		try
		{
			move = Input.GetAxis("Horizontal");
//			maxSpeed = 3.0f;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

			if((move > 0.0f && isFacingRight == false) || (move < 0.0f && isFacingRight == true))
			{
				Flip ();
			}
		}
		catch(UnityException error)
		{
			Debug.LogError(error.ToString());
		}
//		finally
//		{
//			Debug.LogWarning ("Our input check failed!");
//		}

		float h = Input.GetAxis("Horizontal");

		animator.SetFloat("Speed", Mathf.Abs (move));
		print (maxSpeed);
	
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;							// Invert the value of facingRight
		Vector3 playerScale = transform.localScale;			// Invert the local transform
		playerScale.x = playerScale.x * -1;					// Invert the X scale of the Vector 3
		transform.localScale = playerScale;				    // Match the transforms local scale to the Vector 3
	}
	}
