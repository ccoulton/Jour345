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

	//shots
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	//Spinning control
	public int numofSpins;
	public int spinRate;
	public float spinCD;
	private int spinDir;
	private float nextSpin;
	private float totalSpin;
	private bool spinning = false;

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			this.GetComponent<AudioSource>().Play();
		}

		if (Input.GetKeyDown (KeyCode.Q) && Time.time > nextSpin) {
			spinning = true;
			nextSpin = Time.time + spinCD;
			if (rigidBody.velocity.x < 0)
				spinDir = 1;
			else
				spinDir = -1;
		}


	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorz, 0.0f, moveVert);
		rigidBody.velocity = movement * speed;
		rigidBody.position = new Vector3(
			Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax),
			0.0f,
			Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax));

		rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);

		if (spinning) {
			rigidBody.transform.Rotate(0,0,Time.deltaTime*spinRate*spinDir, Space.World);
			totalSpin += Time.deltaTime * spinRate;
			if (totalSpin >= 360*numofSpins) {
				totalSpin = 0.0f;
				spinning = false;
			}
		}
	}

	public bool isSpinning(){
		return spinning;
	}
}