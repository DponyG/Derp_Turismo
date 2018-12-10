using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour {

    private static int minuteCount;
    private static int secondCount;
    private static float milliCount;
    private static string milliDisplay;

    public GameObject minuteBox;
    public GameObject secondBox;
    public GameObject milliBox;

    public GameObject LapCompleteTrigger;

  

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (LapCompleteTrigger.GetComponent<LapComplete>().getLaps() < 1) {


            MilliCount += Time.deltaTime * 10;
            MilliDisplay = MilliCount.ToString("F0");
            milliBox.GetComponent<Text>().text = "" + MilliDisplay;

            if (MilliCount >= 10) {
                MilliCount = 0;
                SecondCount++;
            }

            if (SecondCount <= 9) {
                secondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
            } else {
                secondBox.GetComponent<Text>().text = SecondCount + ".";
            }

            if (SecondCount >= 60) {
                SecondCount = 0;
                MinuteCount++;
            }

            if (MinuteCount <= 9) {
                minuteBox.GetComponent<Text>().text = "0" + MinuteCount + ".";
            } else {
                minuteBox.GetComponent<Text>().text = MinuteCount + ".";
            }
        }
    }

    public int MinuteCount {
        get {
            return minuteCount;
        }

        set {
            minuteCount = value;
        }
    }

    public int SecondCount {
        get {
            return secondCount;
        }

        set {
            secondCount = value;
        }
    }

    public float MilliCount {
        get {
            return milliCount;
        }

        set {
            milliCount = value;
        }
    }

    public string MilliDisplay {
        get {
            return milliDisplay;
        }

        set {
            milliDisplay = value;
        }
    }


}
