using UnityEngine;
using System.Collections;

public class Balloon_transform : MonoBehaviour {
	private float angle;
	public float degree;
	public float modifier;

	void Update () {
		angle += degree* Mathf.PI/ 180;
		gameObject.transform.localScale = new Vector3(
			9 + Mathf.Cos (angle)*modifier, 
			9 + Mathf.Sin (angle)*modifier,
			0);
	}
}
