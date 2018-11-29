using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

    public GameObject lapManager;
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;
    public GameObject minDisplay;
    public GameObject secDisplay;
    public GameObject milDisplay;

    LapTimeManager lapTime;
    



    // Use this for initialization
    void Start () {
        lapTime = lapManager.GetComponent<LapTimeManager>();
           
    }
	
	// Update is called once per frame
	void Update () {

   
    }

    void OnTriggerEnter(Collider other) {
       if(lapTime.SecondCount <= 9) {
            secDisplay.GetComponent<Text>().text = "0" + lapTime.SecondCount+ ".";
        } else {
            secDisplay.GetComponent<Text>().text = lapTime.SecondCount + ".";
        }
        if (lapTime.MinuteCount <= 9) {
            minDisplay.GetComponent<Text>().text = "0" + lapTime.MinuteCount + ".";
        } else {
            minDisplay.GetComponent<Text>().text = lapTime.MinuteCount + ".";
        }

        milDisplay.GetComponent<Text>().text = lapTime.MilliDisplay;

        lapTime.MinuteCount = 0;
        lapTime.SecondCount = 0;
        lapTime.MilliCount = 0;

        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}
