using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	// Use this for initialization
	void Start () {
		
	}
	
	
	public float speed = 1.5f;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)){
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
		}
		if (Input.GetMouseButtonDown (0)){
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprite3;
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
	}
}


