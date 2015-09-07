using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class Player_Controller : MonoBehaviour {
	public Rigidbody rigidBody;
	public Boundary boundry;
	public float speed;
	public float tilt;
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorz, 0.0f, moveVert);
		rigidBody.velocity = movement * speed;
		rigidBody.position = new Vector3(
			Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax),
			0.0f,
			Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax)
		);

		rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
	}
}
