using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject [] answers;
	private GUIText question;
	private GameObject [] podiums;
	private TextAsset database;

	// Use this for initialization
	void Start () {
		if (answers == null || question == null || podiums == null) {
			answers = GameObject.FindGameObjectsWithTag ("Dragable");
			question= GameObject.FindGameObjectWithTag ("Question").GetComponent<GUIText> ();
			podiums = GameObject.FindGameObjectsWithTag ("Podium");
		}
		loadData ();
		question.text = "Testing";
	}

	void loadData(){
		try{
			string line;
			StreamReader fileReader = new StreamReader("Assets/test.txt", Encoding.ASCII);
			int linenum = 0;
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
