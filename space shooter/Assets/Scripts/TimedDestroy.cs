using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {
	public float lifetime;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, lifetime);
	}
}
