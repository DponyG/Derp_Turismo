using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayersCars : MonoBehaviour {

	private GameObject playerId;
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

	void populateCar(string[] car){
		newOption = new Dropdown.OptionData();
		newOption.text = car[2];
		dropdown.options.Add(newOption);
	}

	
}
