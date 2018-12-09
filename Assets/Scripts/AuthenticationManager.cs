﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuthenticationManager : MonoBehaviour {


    public GameObject buttonLogin;
    public GameObject buttonRegister;
    public GameObject popPanel;
    public GameObject youAreRegistered;
    public GameObject popInvalidUnPw;

    public InputField fieldUserNameText;
    public InputField fieldEmailAddressText;
    public InputField fieldPasswordText;

    public GameObject fieldUserName;
    public GameObject fieldEmailAddress;
    public GameObject fieldPassword;

  

    WWWForm form;
       

	// Use this for initialization
	void Start () {
        popPanel.SetActive(false);
        popInvalidUnPw.SetActive(false);
        youAreRegistered.SetActive(false);
        buttonRegister.GetComponent<Button>().onClick.AddListener(DisplayUsernamePanel);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayUsernamePanel() {
        popPanel.SetActive(true);
        youAreRegistered.SetActive(false);
    }

    public void SubmitButtonTapped() {

        popPanel.SetActive(false);
        youAreRegistered.SetActive(true);

        StartCoroutine("RequestInsert");
    }

    public IEnumerator RequestInsert() {
        string email = fieldEmailAddressText.text;
        string password = fieldPasswordText.text;
        string username = fieldUserNameText.text;
        form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("username", username);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/update_login.php", form);
        yield return w;

        if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

        Debug.Log(w.text);



    }

    public void LoginButtonTapped() {

        StartCoroutine("RequestLogin");
     
    }

    public IEnumerator RequestLogin() {
        string email = fieldEmailAddressText.text;
        string password = fieldPasswordText.text;
        print(email);
        print(password);

        form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        WWW w = new WWW("https://derpturismo.000webhostapp.com/action_login.php", form);
        yield return w;

        if (!string.IsNullOrEmpty(w.error))
            Debug.Log(w.error);

        Debug.Log(w.text);

        if (w.text.Contains("login success")){
            successfulLogin();
        }    
        else
            popInvalidUnPw.SetActive(true);
    }

    void successfulLogin() {
        SceneManager.LoadScene("SelectMode");
    }     
}
