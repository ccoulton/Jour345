using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	Vector3 direction;
	// Use this for initialization
	void Start () {
		direction = transform.forward;
		setVelocity ();
	}

	private void setVelocity(){
		rb.velocity = direction * speed;
	}

	public void Deflect(Vector3 deflected){
		direction = -deflected;
		setVelocity ();
	}
}
