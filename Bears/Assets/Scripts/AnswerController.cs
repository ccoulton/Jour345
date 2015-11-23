using UnityEngine;
using System.Collections;

public class AnswerController : MonoBehaviour {
	private Vector3 screenPosition;
	private Vector3 offset;
	private float YPosition;
	private TextMesh text;
	private GameObject podium;

	void Start(){
		text = gameObject.GetComponentInChildren<TextMesh> ();
		screenPosition = gameObject.transform.position;
	}

	void OnMouseDown(){
		//boxCollider.isTrigger = false;
		YPosition = screenPosition.y;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (
			new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
		Cursor.visible = false;
		if (podium != null) {
			podium.GetComponent<BoxCollider> ().enabled = true;
		}
	}

	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		//curPosition.x = YPosition;
		transform.position = curPosition;
	}

	void OnMouseUp(){
		//boxCollider.isTrigger = true;
		if (podium != null)
			podium.GetComponent<BoxCollider>().enabled = false;
		Cursor.visible = true;
	}

	void OnTriggerEnter(Collider collision){
		Debug.Log ("trigger enter");
		//collision.enabled = false;
		podium = collision.gameObject;
		text.text = "00%";
	}

	void OnTriggerExit(Collider collision){
		Debug.Log ("Trigger Exit");
		//collision.enabled = true;
		podium = null;
		text.text = "##%";
	}
}
