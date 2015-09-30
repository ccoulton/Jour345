using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int lives;
	public GameObject player;
	public GameObject[] hazard;
	public Vector3 spawnValues;
	public float spawnWait,startWait, waveWait;
	private int score;
	public GUIText scoretext;
	public GUIText gameOver;
	public GUIText RestartText;
	bool restart, gameover, respawn;
	// Use this for initialization

	void Start () {
		restart = false;
		gameover = false;
		lives = 3;
		gameOver.text = "";
		RestartText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves (){
		yield return new WaitForSeconds (startWait);
		while(!gameover){
			if (respawn){
				Instantiate(player, player.transform.position, player.transform.rotation);
				respawn = false;
			}
			int hazard_Count = Random.Range (1, 10);
			for (int i=0; i<=hazard_Count; i++) {
				Vector3 spawnPosition = new Vector3 (
			Random.Range (-spawnValues.x, spawnValues.x), 
				spawnValues.y,
				spawnValues.z);
				int objSpawned = Random.Range(0,4);
				Instantiate (hazard[objSpawned], spawnPosition, hazard[objSpawned].transform.rotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
		RestartText.text = "Press 'r' to Restart";
		restart = true;
	}

	void Update(){
		if (restart) 
			if (Input.GetKeyDown (KeyCode.R))
				Application.LoadLevel (Application.loadedLevel);
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoretext.text = "Score: " + score;
	}

	public void GameOver(){
		lives--;
		if (lives == 0) {
			gameOver.text = "GAME OVER";
			gameover = true;
		} 
		else 
			respawn = true;
	}
}
