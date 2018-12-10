using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class LapComplete : MonoBehaviour {

    public GameObject lapManager;
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;
    public GameObject LapCount;
    public GameObject carControls;
    private int LapsDone;

    public int getLaps() {
        return LapsDone;
    }

  

    // Use this for initialization
    void Start () {
       
           
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    void OnTriggerEnter(Collider other) {

        LapsDone += 1;
        carControls.GetComponent<CarController>().setSpeed(0);

        LapCount.GetComponent<Text>().text = "" + LapsDone;

        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}
