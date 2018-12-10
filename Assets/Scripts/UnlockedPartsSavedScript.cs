using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;


public class UnlockedPartsSavedScript : MonoBehaviour {

	private string playerID;

	public GameObject prefab;

	public ToggleGroup toggleGroupBodies;
	public Transform bodiesTransform;
	public ToggleGroup toggleGroupTires;
	public Transform tiresTransform;
	public ToggleGroup toggleGroupEngines;
	public Transform enginesTransform;
	private GameObject playerId;
	WWWForm form;


	void Awake() {
		if (Application.isEditor) {
			playerID = "1";
		}
		else {
			playerId = GameObject.Find("GetPlayerId");
			playerID = playerId.GetComponent<PlayerId>().getId().ToString();
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine("getEngines");
		StartCoroutine("getTires");
		StartCoroutine("getBodies");
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void populateEngine(string[] s) {
		GameObject newPart;
		newPart = (GameObject)Instantiate(prefab, enginesTransform);
		foreach(string ss in s){
			Debug.Log(ss);
		}
		newPart.GetComponent<Text>().text = "Name: " + s[2] + " Cost: $" + s[1]
											+ " Stat: " + s[3];
		newPart.GetComponentInChildren<Toggle>().group = toggleGroupEngines;
		newPart.name = s[2];
	}

	void populateTire(string[] s) {
		GameObject newPart;
		newPart = (GameObject)Instantiate(prefab, tiresTransform);
		foreach(string ss in s){
			Debug.Log(ss);
		}
		newPart.GetComponent<Text>().text = "Name: " + s[2] + " Cost: $" + s[1]
											+ " Stat: " + s[3];
		newPart.GetComponentInChildren<Toggle>().group = toggleGroupTires;
		newPart.name = s[2];
	}

	void populateBody(string[] s) {
		GameObject newPart;
		newPart = (GameObject)Instantiate(prefab, bodiesTransform);
		foreach(string ss in s){
			Debug.Log(ss);
		}
		newPart.GetComponent<Text>().text = "Name: " + s[2] + " Cost: $" + s[1]
											+ " Stat: " + s[3];
		newPart.GetComponentInChildren<Toggle>().group = toggleGroupBodies;
		newPart.name = s[2];
	}


	public IEnumerator getEngines() {

        form = new WWWForm();
        // form.AddField("playerId", playerID);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_engines.php", form);
        yield return w;

		if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

		string data = w.text;
		string[] engineRows = data.Split(';');
		foreach (string s in engineRows) {
			if (!string.IsNullOrEmpty(s)) {
				string[] engine = s.Split(',');
				populateEngine(engine);
			}
		}
		 
    }

	public IEnumerator getTires() {

        form = new WWWForm();
        // form.AddField("playerId", playerID);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_tires.php", form);
        yield return w;

		if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

		string data = w.text;
		string[] tireRows = data.Split(';');
		foreach (string s in tireRows) {
			if (!string.IsNullOrEmpty(s)) {
				string[] tire = s.Split(',');
				populateTire(tire);
			}
		}
		 
    }

	public IEnumerator getBodies() {

        form = new WWWForm();
        // form.AddField("playerId", playerID);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_bodies.php", form);
        yield return w;

		if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

		string data = w.text;
		string[] bodyRows = data.Split(';');
		foreach (string s in bodyRows) {
			if (!string.IsNullOrEmpty(s)) {
				string[] body = s.Split(',');
				populateBody(body);
			}
		}
		 
    }


}
