using UnityEngine;
using System.Collections;

public class CameraRunner : MonoBehaviour {

	public Transform player;

	void Update () 
	{
		transform.position = new Vector3 (player.position.x + 4, 0, -10);
	}
}
