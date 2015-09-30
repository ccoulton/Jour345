using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player")
			Destroy (this.gameObject);
	}
}
