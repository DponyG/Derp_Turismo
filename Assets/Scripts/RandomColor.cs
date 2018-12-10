using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour {

	public Text text;
	float i =0.0f;
	float rate = 1.0f;
	UnityEngine.Color colorStart;
	UnityEngine.Color colorEnd;
	// Use this for initialization
	void Start () {
		colorStart = UnityEngine.Random.ColorHSV();
		colorEnd = UnityEngine.Random.ColorHSV();
	}

	void Update() {
		i+= Time.deltaTime * rate;
		text.color = UnityEngine.Color.Lerp(colorStart, colorEnd, i);

		if (i >= 1){
			i=0;
			colorStart = text.color;
			colorEnd = UnityEngine.Random.ColorHSV();

		}
	}
}
