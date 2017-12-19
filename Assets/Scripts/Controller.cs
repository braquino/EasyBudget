using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	public InputField _description;
	public Dropdown _category;
	public InputField _date;
	public InputField _value;
	public DataService db; 

	public List<string> categs = new List<string>
	{
		"Combustível",
		"Alimentação",
		"Alimentação Bruno",
		"Alimentação Marina",
		"Mercado",
		"Zé",
		"Outros",
		"Emergência"
	};

	void Start () {
		_category.ClearOptions();
		_category.AddOptions(categs);

		db = new DataService ("expenses.db");
	}


	public void Insert(){
		try{
			db.CreateExpense(_description.text,_category.options[_category.value].text,_date.text,double.Parse(_value.text));
			Clear();
			Debug.Log ("Expense successfully added!");
		}catch{
			Debug.Log ("Please, review your input.");
		}
	}
	public void CreateDB(){
		db.CreateDB ();
	}

	public void Today(){
		_date.text = DateTime.Now.ToString("dd/MM/yyyy");
	}

	public void Clear(){
		_description.text = "";
		_date.text = "";
		_value.text = "";
	}

}
