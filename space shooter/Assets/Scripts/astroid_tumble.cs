using UnityEngine;
using System.Collections;

public class astroid_tumble : MonoBehaviour {
	public Rigidbody rigidBody;

	public float tumble;
	// Use this for initialization
	void Start () {
		rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
