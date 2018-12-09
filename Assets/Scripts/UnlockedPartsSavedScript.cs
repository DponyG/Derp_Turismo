using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;


public class UnlockedPartsSavedScript : MonoBehaviour {

	public string fileName;
	public string partName;
	public string directory = "~/";

	public GameObject player;

	public GameObject prefab;

	public ToggleGroup toggleGroup;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < UnityEngine.Random.Range(1,10); i++) {
			saveNewPart(i);
		}

		string[] parts = readParts();
		foreach (string s in parts) {
			PopulatePart(s);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void saveNewPart(int partID) {
		if (!File.Exists(fileName)){
			File.WriteAllText(fileName, partID.ToString() + Environment.NewLine);
		}
		else {
			File.AppendAllText(fileName, partID.ToString() + Environment.NewLine);
		}
	}

	string[] readParts() {
		return File.ReadAllLines(fileName);
	}

	void PopulatePart(string s) {
		GameObject newEngine; 
		newEngine = (GameObject)Instantiate(prefab, transform);
		newEngine.GetComponent<Text>().text = partName + s + "	Cost: $" + UnityEngine.Random.Range(1,100).ToString() 
											+ "	Stat: " + UnityEngine.Random.Range(1,25).ToString();
		newEngine.GetComponentInChildren<Toggle>().group = toggleGroup;
		newEngine.name = partName + s;
	}

	public IEnumerator getParts() {

        form = new WWWForm();
        form.AddField("playerId", playerId);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_engines.php", form);
        yield return w;

        string dataId = w.text;
        Debug.Log(dataId);

        if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

        if (!w.text.Contains("password incorrect") 
            && !w.text.Contains("user not found")){
            int num = Int32.Parse(dataId);
            playerId.GetComponent<PlayerId>().setId(num);
            successfulLogin();

		data = w.text;
		string[] engineRows = data.Split("\n");
		foreach (string s in engineRows) {
			string[] engine = s.Split(",");
			// id
			// cost 
			// name 
			// horsepower 
			// partId
		}
		 
    	}
	}
}
