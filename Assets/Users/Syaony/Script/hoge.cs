using UnityEngine;
using System.Collections;

public class hoge : MonoBehaviour {

	private float distance;

	// Use this for initialization
	void Start () {

		distance = PlayerStatusManeger.playerDistanceToGoal;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(100,10,100,100), ""+distance);
	}
}
