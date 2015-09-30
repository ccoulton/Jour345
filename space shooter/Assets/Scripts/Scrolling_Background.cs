using UnityEngine;
using System.Collections;

public class Scrolling_Background: MonoBehaviour {
	public float Scrollspeed;
	private Vector2 savedOffset;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		savedOffset = rend.sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		float y = Mathf.Repeat (Time.time*Scrollspeed, 1);
		Vector2 offset = new Vector2 (savedOffset.x, y);
		rend.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	void onDisable(){
		rend.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}
