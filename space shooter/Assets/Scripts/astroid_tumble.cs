using UnityEngine;
using System.Collections;

public class astroid_tumble : MonoBehaviour {
	public Rigidbody rigidBody;
	private float scaling;
	public float tumble;
	// Use this for initialization
	void Start () {
		rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
		scaling = Random.Range (0.5f, 2.0f);
		transform.localScale = new Vector3 (1, 1, 1) * scaling;
	}

	public float getScaling(){
		return scaling;
	}
}
