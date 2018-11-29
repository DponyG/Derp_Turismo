using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCompleteTrigger : MonoBehaviour {

    public GameObject lapCompleteTrig;
    public GameObject halfLapTrig;

   

    void OnTriggerEnter() {
        lapCompleteTrig.SetActive(true);
        halfLapTrig.SetActive(false);
    }
}
