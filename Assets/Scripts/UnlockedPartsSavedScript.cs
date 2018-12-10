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

	public ToggleGroup toggleGroup;
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
		StartCoroutine("getParts");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void populatePart(string[] s) {
		GameObject newEngine;
		newEngine = (GameObject)Instantiate(prefab, transform);
		foreach(string ss in s){
			Debug.Log(ss);
		}
		newEngine.GetComponent<Text>().text = "Name: " + s[2] + " Cost: $" + s[1]
											+ " Stat: " + s[3];
		newEngine.GetComponentInChildren<Toggle>().group = toggleGroup;
		newEngine.name = s[2];
	}


	public IEnumerator getParts() {

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
				populatePart(engine);
			}
		}
		 
    }


}
