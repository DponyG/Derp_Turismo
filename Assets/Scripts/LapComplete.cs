using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

    public GameObject lapManager;
    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;
    public GameObject LapCount;
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
        LapCount.GetComponent<Text>().text = "" + LapsDone;
        halfLapTrig.SetActive(true);
        lapCompleteTrig.SetActive(false);
    }
}
