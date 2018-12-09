using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;


public class UnlockedPartsSavedScript : MonoBehaviour {

	public string fileName = "tester.txt";
	public string directory = "~/";

	public GameObject player;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 100; i++) {
			saveNewPart(i);
		}

		string[] parts = readParts();
		foreach (string s in parts) {
			Debug.Log(s);
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
}
