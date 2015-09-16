using UnityEngine;
using System.Collections;

public class enemyAi : MonoBehaviour {
	
	public Transform target;//set target from inspector instead of looking in Update
	public float speed = 3f;
	
	
	void Update() {
		//rotate to look at the player
		transform.LookAt(target.position);
		//correcting the original rotation
		transform.Rotate(new Vector3(0,-90,0),Space.Self);
		
		//move towards the player if distance from target is greater than 1
		if (Vector3.Distance(transform.position,target.position)>1f) {
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}
	}
}