using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour {

    public GameObject countDown;
    public AudioSource getReady;
    public AudioSource goAudio;
    public GameObject lapTimer;
    public GameObject test;
 
   

	// Use this for initialization
	void Start () {
        StartCoroutine(countStart());

       lapTimer.SetActive(false);
      


    }

    IEnumerator countStart() {
        yield return new WaitForSeconds(0.5f);

        countDown.GetComponent<Text>().text = "3";
        getReady.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "2";
        getReady.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "1";
        getReady.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        goAudio.Play();
        lapTimer.SetActive(true);
      


    }


}
