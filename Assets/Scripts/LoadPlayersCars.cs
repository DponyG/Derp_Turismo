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
    public GameObject savebutton;

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
        savebutton.GetComponent<Button>().onClick.AddListener(saveCar);
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
        form.AddField("playerId", id);
		form.AddField("car_name", name);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/get_car_values.php", form);
        yield return w;

        if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);
      
		string data = w.text;
		string[] car = data.Split(',');
        if (car != null && car.Length > 0)
        {
            populateToggles(car);
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
		StartCoroutine(getCarValues(playerID, change.options[change.value].text));
    }

	void populateToggles(string[] car) {
		string engineTitle = "Engine " + car[4];
		engineToggle = GameObject.Find(engineTitle);
		engineToggle.GetComponentInChildren<Toggle>().isOn = true;

        string bodyTitle = "Body " + car[5];
        bodyToggle = GameObject.Find(bodyTitle);
        bodyToggle.GetComponentInChildren<Toggle>().isOn = true;

        string tireTitle = "Tire " + car[3];
        tireToggle = GameObject.Find(tireTitle);
        tireToggle.GetComponentInChildren<Toggle>().isOn = true;
    }

    void saveCar()
    {
        Debug.Log("YOU CLICKED ME");
    }
	
}
