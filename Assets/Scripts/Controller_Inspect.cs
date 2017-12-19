using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Inspect : MonoBehaviour {

	public Text _mainBox;
	public DataService db = new DataService ("expenses.db");
	public Text _IDBox;

	// Use this for initialization
	void Start () {
		GenerateText ();
	}
	
	// Update is called once per frame
	public void Delete () {
		try{db.DeleteById (_IDBox.text);}
		catch{Debug.Log ("Error");}
		_IDBox.text = "";
		GenerateText ();
	}

	void GenerateText(){
		var expenses = db.GetExpenses ();
		_mainBox.text = "";
		foreach (var item in expenses) {
			_mainBox.text += (item.ToString () + "\n");
		}
	}
}
