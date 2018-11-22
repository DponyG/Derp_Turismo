using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthenticationManager : MonoBehaviour {

    public GameObject buttonJoinGame;
    public GameObject buttonRegister;
    public GameObject mainMenu;

    public GameObject fieldUserName;
    public GameObject fieldEmailAddress;
    public GameObject fieldPassword;
    public GameObject fieldReenterPassword;

    public Text userName;
    public Text textEmail;
    public Text textPassword;
    public Text textReenterPassword;
       

	// Use this for initialization
	void Start () {
        displayLoginPanel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void displayLoginPanel() {
        buttonRegister.SetActive(false);
        fieldReenterPassword.SetActive(false);
    }
}
