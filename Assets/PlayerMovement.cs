using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	Animator animator;	
	public Sprite sprite1;
	public Sprite sprite2;
	public bool isFacingRight = true;	
	public float jumpSpeed = 1.5f;
	public float superSpeed = 10;
	public float superJump = 4f;
	//public Sprite sprite3;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
	}
	
	
	public float speed = 1.5f;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)){
			speed = 10f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)){
			speed = 1.5f;
		}
		if (Input.GetKeyDown(KeyCode.LeftShift)){
			jumpSpeed = superJump;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)){
			speed = 1.5f;
		}


		if (Input.GetKey(KeyCode.RightArrow)){
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
			float h = Input.GetAxis("Horizontal");
			
			animator.SetFloat("Speed", Mathf.Abs (speed));
			print (speed);
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
		}
		if (Input.GetMouseButtonDown (0)){
			transform.position += Vector3.up * speed * Time.deltaTime * 3;
		}
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * jumpSpeed * Time.deltaTime * 3;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}



			

	
	}
	//void Flip()
	//{
		//isFacingRight = !isFacingRight;							// Invert the value of facingRight
		//Vector3 playerScale = transform.localScale;			// Invert the local transform
		//playerScale.x = playerScale.x * -1;					// Invert the X scale of the Vector 3
		//transform.localScale = playerScale;				    // Match the transforms local scale to the Vector 3
	//}
	void Flip()
	{
		isFacingRight = !isFacingRight;							// Invert the value of facingRight
		Vector3 playerScale = transform.localScale;			// Invert the local transform
		playerScale.x = playerScale.x * -1;					// Invert the X scale of the Vector 3
		transform.localScale = playerScale;				    // Match the transforms local scale to the Vector 3
	}
}



