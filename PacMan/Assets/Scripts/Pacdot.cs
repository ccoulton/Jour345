using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "Pacman")
			Destroy (this.gameObject);
	}
}
