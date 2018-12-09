using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour {

	public Button garageButton;
	public Button raceButton;

	// Use this for initialization
	void Start () {
		garageButton.onClick.AddListener(delegate {Navigate("GarageScene"); });
		raceButton.onClick.AddListener(delegate {Navigate("RaceSelectionScene"); });
	}
	
	
	void Navigate(string scene) {
		SceneManager.LoadScene(scene);
	}

}
