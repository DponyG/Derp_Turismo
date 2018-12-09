using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthenticationManager : MonoBehaviour {

    public GameObject buttonLogin;
    public GameObject buttonSignUp;
    public GameObject buttonRegister;

    public InputField fieldUserNameText;
    public InputField fieldEmailAddressText;
    public InputField fieldPasswordText;
    public InputField fieldReenterPasswordText;

    public GameObject fieldUserName;
    public GameObject fieldEmailAddress;
    public GameObject fieldPassword;
    public GameObject fieldReenterPassword;

    public Text userName;
    public Text textEmail;
    public Text textPassword;
    public Text textReenterPassword;

    WWWForm form;
       

	// Use this for initialization
	void Start () {
        DisplayLoginPanel();
        buttonRegister.GetComponent<Button>().onClick.AddListener(DisplayRegistrationPanel);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayLoginPanel() {

        buttonRegister.SetActive(true);
        buttonLogin.SetActive(true);
        fieldReenterPassword.SetActive(false);
        fieldEmailAddress.SetActive(false);
        fieldPassword.SetActive(false);
        buttonSignUp.SetActive(false);

    }

    public void DisplayRegistrationPanel() {

        buttonRegister.SetActive(false);
        buttonLogin.SetActive(false);
        fieldEmailAddress.SetActive(true);
        fieldPassword.SetActive(true); 
        buttonSignUp.SetActive(true);
        fieldReenterPassword.SetActive(true);


    }

    public void LoginButtonTapped() {
    
        StartCoroutine("RequestLogin");
    }

    //public IEnumerator InsertUser() {
    //    string email = fieldEmailAddress.text;
    //    string password = textPassword
    //}

    public IEnumerator RequestLogin() {
        string email = fieldEmailAddressText.text;
        string password = textPassword.text;
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
    }
}
