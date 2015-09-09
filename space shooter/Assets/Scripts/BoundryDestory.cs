using UnityEngine;
using System.Collections;

public class BoundryDestory : MonoBehaviour {

	void OnTriggerExit(Collider input){
		Destroy (input.gameObject);
	}

}
