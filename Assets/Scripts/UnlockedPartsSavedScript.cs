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

	// Use this for initialization
	void Start () {
		for (int i = 0; i < UnityEngine.Random.Range(1,10); i++) {
			saveNewPart(i);
		}

		string[] parts = readParts();
		foreach (string s in parts) {
			PopulateEngine(s);
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

	void PopulateEngine(string s) {
		GameObject newEngine; 
		newEngine = (GameObject)Instantiate(prefab, transform);
		newEngine.GetComponent<Text>().text = partName + s + "	Cost: $" + UnityEngine.Random.Range(1,100).ToString();
		newEngine.name = "Engine" + s;
	}
}
