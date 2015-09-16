using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	[HideInInspector] 
	public bool isFacingRight = true;			// Is the player sprite facing the righthand side of the screen?
	[HideInInspector]
	public bool isGrounded = false;				// Is the player touching ground?

	public float maxSpeed = 7.0f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 650.0f;			// Amount of force added when the player jumps.
	
	public Transform groundCheck;				// GameObject transform used for ground check
	public LayerMask groundLayers;				// Mask denoting layers that count as "ground"

	private float groundCheckRadius = 0.2f;		// Distance from transform center that we check for ground

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Check for player input
		// Is the player pressing jump?  Are they on the ground?
		if(Input.GetButtonDown("Jump"))
		{
			// Is the player on the ground?
			if(isGrounded == true)
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);		// Zero out vertical velocity to prevent increased jump height when going up an incline
				this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));					// Apply jump force value
			}
			else
			{
				Debug.Log("Jump pressed while not grounded");
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
			float move = Input.GetAxis("Horizontal");
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
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;							// Invert the value of facingRight
		Vector3 playerScale = transform.localScale;			// Invert the local transform
		playerScale.x = playerScale.x * -1;					// Invert the X scale of the Vector 3
		transform.localScale = playerScale;				    // Match the transforms local scale to the Vector 3
	}
}
