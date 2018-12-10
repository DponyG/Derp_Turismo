using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerId : MonoBehaviour {

    
    public static PlayerId playerId;

    [SerializeField]
    private int _id;
   
    public void setId(int id) {
        _id = id;
        
    }

    public int getId() {
        return _id;
    }

    
    

    private void Awake() {
        if(playerId == null) {
            DontDestroyOnLoad(gameObject);
            playerId = this;
        }
        else if(playerId != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
