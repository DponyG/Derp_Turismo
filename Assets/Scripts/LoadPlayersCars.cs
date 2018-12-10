using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class LoadPlayersCars : MonoBehaviour {

	private GameObject playerId, engineToggle, bodyToggle, tireToggle;
	public string playerID;
	WWWForm form;
	public Dropdown dropdown;
	private Dropdown.OptionData newOption;

	void Awake() {
		if (Application.isEditor) {
			playerID = "1";
		}
		else {
			playerId = GameObject.Find("GetPlayerId");
			playerID = playerId.GetComponent<PlayerId>().getId().ToString();
		}

		dropdown.onValueChanged.AddListener(delegate {
                dropdownValueChanged(dropdown);});
	}

	void Start () {
		StartCoroutine("getCars");
	}

	public IEnumerator getCars() {

        form = new WWWForm();
        form.AddField("playerId", playerID);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_players_cars.php", form);
        yield return w;

		if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

		string data = w.text;
		string[] carRows = data.Split(';');
		foreach (string s in carRows) {
			if (!string.IsNullOrEmpty(s)) {
				string[] car = s.Split(',');
				populateCar(car);
			}
		}
		 
    }

	public IEnumerator getCarValues(string id, string name) {
		form = new WWWForm();
        form.AddField("playerId", Int32.Parse(id));
		form.AddField("car_name", name);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_car_values.php", form);
        yield return w;

		if (string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);
        Debug.Log(w.text);
		string data = w.text;
		string[] car = data.Split(',');
        if (car != null && car.Length > 0)
        {
            //populateToggles(car);
        }
        else
            Debug.Log("Error getting Car data.");
	}

	void populateCar(string[] car){
		newOption = new Dropdown.OptionData();
		newOption.text = car[2];
		dropdown.options.Add(newOption);
	}

	void dropdownValueChanged(Dropdown change){
		StartCoroutine(getCarValues(playerID, change.itemText.text));
    }

	void populateToggles(string[] car) {
		string engineTitle = "Engine " + car[4];
        //Debug.Log(engineTitle);
		engineToggle = GameObject.Find(engineTitle);
		//engineToggle.GetComponent<Toggle>().isOn = true;
	}

	
}
