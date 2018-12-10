using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadPlayersCars : MonoBehaviour {

	private GameObject playerId, engineToggle, bodyToggle, tireToggle;
	public string playerID;
	WWWForm form;
	public Dropdown dropdown;
    public Dropdown currDropDown;
	private Dropdown.OptionData newOption;
    public GameObject savebutton;
    public GameObject deleteButton;

    public GameObject newCarName;
    private string car_name;
  

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
        savebutton.GetComponent<Button>().onClick.AddListener(getSaveCarData);
        deleteButton.GetComponent<Button>().onClick.AddListener(deleteCarButton);

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
        currDropDown = change;
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

    void getSaveCarData()
    {
        
        ToggleGroup tireGroup, engineGroup, bodyGroup;
        string currentTire = "";
        string currentEngine = "";
        string currentBody = "";
        tireGroup = GameObject.Find("TiresContent").GetComponent<ToggleGroup>();
        engineGroup = GameObject.Find("EnginesContent").GetComponent<ToggleGroup>();
        bodyGroup = GameObject.Find("BodiesContent").GetComponent<ToggleGroup>();
        foreach (Toggle t in tireGroup.ActiveToggles()) {
            currentTire = (t.transform.parent.name);
            currentTire = Regex.Replace(currentTire, "[^0-9.]", "");
        }
        foreach (Toggle t in engineGroup.ActiveToggles()){
            currentEngine = (t.transform.parent.name);
            currentEngine = Regex.Replace(currentEngine, "[^0-9.]", "");
        }
        foreach (Toggle t in bodyGroup.ActiveToggles()) {
            currentBody = (t.transform.parent.name);
            currentBody = Regex.Replace(currentBody, "[^0-9.]", "");
        }
        //Debug.Log(currentTire + currentEngine + currentBody);
        StartCoroutine(SaveCar(currentTire, currentEngine, currentBody));
    }

    public IEnumerator SaveCar(string tires, string engine, string body) {

        string _newCarName = newCarName.GetComponent<InputField>().text;
        string oldcarname = currDropDown.options[currDropDown.value].text;
        if (_newCarName == "") {
            _newCarName = oldcarname;
        }
        
        form = new WWWForm();
        form.AddField("playerid", playerID);
        form.AddField("oldname", oldcarname);
        form.AddField("name", _newCarName);
        form.AddField("tires", tires);
        form.AddField("engine", engine);
        form.AddField("body", body);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/save_cars.php", form);
        yield return w;
        Debug.Log(w.text);
        if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

        SceneManager.LoadScene("GarageScene");

    }

    void deleteCarButton() {
        StartCoroutine("deleteCar");
        
        
    }

     IEnumerator deleteCar() {
        string name = currDropDown.options[currDropDown.value].text;
        form = new WWWForm();
        form.AddField("playerId", playerID);
        form.AddField("car_name", name);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/delete_car.php", form);
        yield return w;


        if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);
        Debug.Log(name);
        SceneManager.LoadScene("GarageScene");
   
    }
}
