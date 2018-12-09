using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletScript : MonoBehaviour {

	private GameObject playerId;

	// Use this for initialization
	void Start () {
		playerId = GameObject.Find("GetPlayerId");
		Debug.Log("~~~~~");
		Debug.Log(playerId.GetComponent<PlayerId>().getId());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
