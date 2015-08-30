using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	float speed;
	Rigidbody rigidBody;
	private int count;
	public Text scorecounter;
	public Text winMessage;

	void Start(){
		speed = 11;
		rigidBody = GetComponent <Rigidbody> ();
		count = 0;
		setScoreText ();
		winMessage.text = "";
	}
	
	void Update(){
		
	}
	
	void FixedUpdate(){
		float moveHorz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");
		Vector3 moveVect = new Vector3 (moveHorz, 0, moveVert);
		rigidBody.AddForce (moveVect*speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Can")) {
			other.gameObject.SetActive(false);
			count += 1;
			setScoreText();
		}
	}

	void setScoreText(){
		scorecounter.text = "Score: " + count.ToString ();
		if (count > 11) {
			winMessage.text = "You got all the bug butt JUICE!\nYou Win?";
		}
	}
}
