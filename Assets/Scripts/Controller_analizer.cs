using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Controller_analizer : MonoBehaviour {

	public Canvas _anCanvas;
	public Transform _category;
	public DataService db = new DataService ("expenses.db"); 
	public Text _totalBox;
	string[,] categs = new string[,]
	{
		{"Combustível","834"},
		{"Alimentação","400"},
		{"Alimentação Bruno","200"},
		{"Alimentação Marina","320"},
		{"Mercado","800"},
		{"Zé","100"},
		{"Outros","300"},
		{"Emergência","300"}
	};

	// Use this for initialization
	void Start () {
		var expenses = db.GetExpenses ();
		foreach (var x in expenses)
			print (x.ToString ());
		for (int i = 0; i < categs.Length / 2; i++) {
			var inst = Instantiate (_category, new Vector3 (70, 1050 - (i * 50), 0), Quaternion.identity);
			inst.transform.SetParent (_anCanvas.transform, true);
			Text[] dummy = inst.GetComponentsInChildren<Text> ();
			dummy[0].text = categs[i,0];
			dummy[1].text = expenses.Where (x => x.Category == categs[i,0]).Sum (x => x.Value).ToString();
			dummy[2].text = categs[i,1];
		}

		_totalBox.text = string.Format ("Total                    {0:F2}   {1:F2}", expenses.Sum(x => x.Value), SumCategs());

	}

	double SumCategs(){
		try{
			double result = 0;
			for (int i = 0; i < categs.Length / 2; i++) 
				result += double.Parse (categs [i,1]);
			return result;
		} catch {
			
		}
		return 0.0;
	}
	

}
