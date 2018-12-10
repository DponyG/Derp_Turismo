using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadScene : MonoBehaviour {

    public Button button;

    

	// Use this for initialization
	void Start () {
        button.GetComponent<Button>().onClick.AddListener(LoadScene);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("RaceArea01");
    }
}
