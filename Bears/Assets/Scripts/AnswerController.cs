using UnityEngine;
using System.Collections;

public class AnswerController : MonoBehaviour {
	private Vector3 screenPosition;
	private Vector3 offset;
	private TextMesh text;
	private GameObject podium;
	private Vector3 defaultScale;
	private Quaternion defaultRot;

	void Start(){
		text = gameObject.GetComponentInChildren<TextMesh> ();
		screenPosition = gameObject.transform.position;
		defaultScale = gameObject.transform.localScale;
		defaultRot = gameObject.transform.localRotation;
	}

	void OnMouseDown(){
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (
			new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
		Cursor.visible = false;
		if (podium != null) { //if answer is on a podium already
			//snap it back to the orginal shape
			podium.GetComponent<BoxCollider> ().enabled = true; //turn on the podium again
			gameObject.transform.localScale = defaultScale;
			gameObject.transform.localRotation = defaultRot;
		}
	}

	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition;
	}

	void OnMouseUp(){
		if (podium != null) { //podium is collided
			podium.GetComponent<BoxCollider> ().enabled = false; //turn off podium collider
			//snap the answer to the podium object.
			gameObject.transform.position = podium.gameObject.transform.position; 
			gameObject.transform.localRotation = podium.gameObject.transform.localRotation;
			gameObject.transform.localScale = podium.gameObject.transform.localScale;
		}
		else
			//snap answer back to default position if no podium hit
			gameObject.transform.position = screenPosition;
		Cursor.visible = true;
	}

	void OnTriggerEnter(Collider collision){
		Debug.Log ("trigger enter");
		podium = collision.gameObject;
	}

	void OnTriggerExit(Collider collision){
		Debug.Log ("Trigger Exit");
		podium = null;
	}
}
