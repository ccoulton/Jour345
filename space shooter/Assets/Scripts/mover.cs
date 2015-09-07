using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
