using UnityEngine;
using System.Collections;

public class astroid_tumble : MonoBehaviour {
	public Rigidbody rigidBody;
	public GameObject explosion;
	public GameObject playerExplosion;

	public float tumble;
	// Use this for initialization
	void Start () {
		rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
	}

	void OnTriggerEnter(Collider input){
		if (input.tag == "Boundry") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (input.tag == "Player") {
			Instantiate(playerExplosion, input.transform.position, input.transform.rotation);
			//Done_GameController.GameOver();
		}
		Destroy (input.gameObject);
		Destroy (gameObject);

	}
}
