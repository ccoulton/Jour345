using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	public GameObject shot;
	public Transform[] shotSpawn;
	public float fireRate;
	public float delay;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire(){
		for (int index= 0; index < shotSpawn.Length; index++){
			Instantiate(shot, shotSpawn[index].position, shotSpawn[index].rotation);
		}
		GetComponent<AudioSource> ().Play ();
	}
}
