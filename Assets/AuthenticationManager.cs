using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthenticationManager : MonoBehaviour {

    public GameObject buttonJoinGame;
    public GameObject buttonRegister;
    public GameObject mainMenu;

    public GameObject fieldUserName;
    public InputField fieldEmailAddress;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayLoginPanel() {
        buttonRegister.SetActive(false);
        fieldReenterPassword.SetActive(false);
    }

    public void LoginButtonTapped() {
    
        StartCoroutine("RequestLogin");
    }

    public IEnumerator RequestLogin() {
        string email = fieldEmailAddress.text;
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
