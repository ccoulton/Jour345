using UnityEngine;
using System.Collections;

public class ContactDestroy : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
	}

	void OnTriggerEnter(Collider input){
		if (input.tag == "Boundry") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (input.tag == "Player") {
			Instantiate(playerExplosion, input.transform.position, input.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore (scoreValue);
		Destroy (input.gameObject);
		Destroy (gameObject);
	}
}
