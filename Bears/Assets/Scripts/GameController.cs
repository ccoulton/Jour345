using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public GameObject [] respawn;
	public GameObject [] answers;
	public GameObject [] podiums;
	private GUIText question;
	private GUIText source;
	private int questionIndex;
	private Database database;
	public GameObject Answer;

	// Use this for initialization
	void Start () {
		if (respawn == null || question == null || podiums == null) {
			respawn = GameObject.FindGameObjectsWithTag ("Respawn");
			question= GameObject.FindGameObjectWithTag ("Question").GetComponent<GUIText> ();
			podiums = GameObject.FindGameObjectsWithTag ("Podium");
			database = new Database();
			source = GameObject.FindGameObjectWithTag("Source");
		}
		database.loadData ("Assets/QuestionsES.tsv");
		Debug.Log (database.Length());
		createAnswers ();
	}

	void createAnswers(){
		questionIndex = Random.Range(0, database.Length()); //random in range of questions length
		Question currentquestion = database.getQuestion(questionIndex);
		question.text = database.getFormatedQuestion(40, questionIndex);
		source.text = currentquestion.source;
		for (int index = 0; index<currentquestion.keys.Length; index++) {
			GameObject temp = (GameObject) Instantiate (Answer, respawn [index].transform.localPosition, Answer.transform.localRotation);
			temp.GetComponentInChildren<TextMesh>().text = currentquestion.values[index];
			podiums[index].gameObject.GetComponentInChildren<TextMesh>().text = currentquestion.keys[index];
		}
		answers = GameObject.FindGameObjectsWithTag ("Dragable");
		if (answers.GetLength (0) == 2) {
			podiums [3].gameObject.GetComponentInChildren<TextMesh> ().text = "";
		}
	}

	void Update(){
		int podiumsDisabled = 0;
		foreach (GameObject podium in podiums)
			if (!podium.GetComponent<BoxCollider> ().enabled)
				podiumsDisabled++;
		if (answers != null && podiums != null) {
			if (podiumsDisabled == answers.GetLength (0)){
				question.text = "Checking";
				for(int index = 0; index < answers.GetLength; index++){
					database.getQuestion(questionIndex).values[index] = answers[index].GetComponentInChildren<TextMesh>().text;
				}
			}
			//do game stuff here scoring checking values to keys
		}
	}
}
