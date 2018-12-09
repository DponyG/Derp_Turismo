using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float red = Random.Range(0.0f, 1.0f);
		float green = Random.Range(0.0f, 1.0f);
		float blue = Random.Range(0.0f, 1.0f);
		text.color = new Color (red, green, blue);
	}
}
