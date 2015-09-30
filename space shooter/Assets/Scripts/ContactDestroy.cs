using UnityEngine;
using System.Collections;

public class ContactDestroy : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private int score;
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
		} else if ((input.tag == "Enemy") && (gameObject.tag == "Enemy")) {
			return;
		}
		if (input.tag == "Player") {
			if (!input.GetComponent<Player_Controller> ().isSpinning()) {
				Instantiate (playerExplosion, input.transform.position, input.transform.rotation);
				gameController.GameOver ();
				//Destroy(input.gameObject);
			}
			else {
				GetComponent<mover>().Deflect(new Vector3(
					gameObject.transform.position.x- input.gameObject.transform.position.x,
					0.0f,
					gameObject.transform.position.z-input.gameObject.transform.position.z));
				return;
			}
		}
		if (explosion != null)
			Instantiate (explosion, transform.position, transform.rotation);
		if (gameObject.tag != "Enemy")
			score = Mathf.RoundToInt (scoreValue / (gameObject.GetComponent<astroid_tumble> ().getScaling () * 2));
		else
			score = scoreValue;
		gameController.AddScore (score);
		Destroy (input.gameObject);
		Destroy (gameObject);
	}
}
