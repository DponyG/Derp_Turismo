using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour {

	public Button garageButton;
	public Button raceButton;
    public Button backButton;

    // Use this for initialization
    void Start () {
		garageButton.onClick.AddListener(delegate {Navigate("GarageScene"); });
		raceButton.onClick.AddListener(delegate {Navigate("RaceSelectionScene"); });
        backButton.onClick.AddListener(delegate { Navigate("Menu"); });
    }
	
	
	void Navigate(string scene) {
		SceneManager.LoadScene(scene);
	}

}
