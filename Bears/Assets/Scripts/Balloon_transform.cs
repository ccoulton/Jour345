using UnityEngine;
using System.Collections;

public class Balloon_transform : MonoBehaviour {
	private float angle;
	public float degree;
	// Use this for initialization
	void Start () {
	}
	

	void Update () {
		angle += degree* Mathf.PI/ 180;
		gameObject.transform.localScale = new Vector3(
			8 + Mathf.Cos (angle), 8 + Mathf.Sin (angle),
		                                               0);
	}
}
