using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public struct Question{
	public string question;
	public string[] keys;
	public string[] values;
	public string source;
};

public class Database : MonoBehaviour{

	private List<Question> questions;

	public Database(){
		questions = new List<Question> ();
	}

	public int Length(){
		return questions.Count;
	}

	public Question getQuestion(int index){
		return questions [index];
	}

	public string getFormatedQuestion(int lineBreak, int index){
		string[] words = questions[index].question.Split(' ');
		string line = "";
		string final = "";
		foreach (string part in words) {
			string temp = line+" "+part;
			if (temp.Length > lineBreak){
				final += line+"\n";
				line = part;
			}
			else{
				line = temp;
			}
		}
		final += line;
		return final.Substring (1, final.Length - 1);
	}

	public void loadData(string filename){
		try{
			string line;
			StreamReader fileReader = new StreamReader("Assets/QuestionsES.tsv", Encoding.UTF8);
			Question temp = new Question();
			using(fileReader){
				do{
					line = fileReader.ReadLine(); //question
					if (line != null){
						temp.question = line.TrimEnd('\t');
						line = fileReader.ReadLine(); //keys
						//Debug.Log (line);
						temp.keys = line.TrimStart('\t').TrimEnd('\t').Split('\t');
						line = fileReader.ReadLine(); //junk
						line = fileReader.ReadLine(); //values
						temp.values = line.TrimStart('\t').TrimEnd('\t').Split('\t');
						temp.source = fileReader.ReadLine(); //source
						questions.Add(temp);
						line = fileReader.ReadLine(); //spacer
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
		Debug.Log (questions[0].ToString());
	}
}
