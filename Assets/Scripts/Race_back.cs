using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Race_back : MonoBehaviour
{

    public Button backButton;

    // Use this for initialization
    void Start()
    {
        backButton.onClick.AddListener(delegate { Navigate("SelectMode"); });
    }


    void Navigate(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
