using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject [] respawn;
	private GameObject [] answers;
	private GUIText question;
	private GameObject [] podiums;
	private TextAsset database;
	public GameObject Answer;

	// Use this for initialization
	void Start () {
		if (answers == null || question == null || podiums == null) {
			respawn = GameObject.FindGameObjectsWithTag ("Respawn");
			question= GameObject.FindGameObjectWithTag ("Question").GetComponent<GUIText> ();
			podiums = GameObject.FindGameObjectsWithTag ("Podium");
			for(var index = 0; index<3; index++)
				Instantiate(Answer, respawn[index].transform.position, Answer.transform.localRotation);
			answers = GameObject.FindGameObjectsWithTag("Dragable");
		}
		loadData ();
		question.text = "Testing";
	}

	void loadData(){
		try{
			string line;
			StreamReader fileReader = new StreamReader("Assets/test.txt", Encoding.ASCII);
			//int linenum = 0;
			using(fileReader){
				do{
					line = fileReader.ReadLine();
					if (line != null){
						Debug.Log(line);
					//do stuff on line like parse it
					}
				}while(line != null);
				fileReader.Close();
				return;
			}
		}
		catch(IOException e){
			Debug.Log(e.Message);
			return;
		}
	}

	void Update(){
		int podiumsDisabled = 0;
		foreach (GameObject podium in podiums)
			if (!podium.GetComponent<BoxCollider>().enabled)
				podiumsDisabled++;
		if (podiumsDisabled == answers.GetLength(0))
			question.text = "Checking";
		else
			question.text = "Testing";
	}
}
