using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;
	public bool isFacingRight = true;	
	//public Sprite sprite3;
	// Use this for initialization
	void Start () {
		
	}
	
	
	public float speed = 1.5f;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)){
			//gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			//gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
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
			transform.position += Vector3.up * speed * Time.deltaTime * 3;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}



			
		if (Input.GetKeyDown(KeyCode.LeftShift)){
			speed = 10f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)){
			speed = 1.5f;
		}

	}
	void Flip()
	{
		isFacingRight = !isFacingRight;							// Invert the value of facingRight
		Vector3 playerScale = transform.localScale;			// Invert the local transform
		playerScale.x = playerScale.x * -1;					// Invert the X scale of the Vector 3
		transform.localScale = playerScale;				    // Match the transforms local scale to the Vector 3
	}
}


