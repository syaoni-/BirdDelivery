using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button(new Rect(Screen.width/10*3, Screen.height/10*4, Screen.width/10*3, Screen.height/10*2), "Start")) {
			FadeManeger.Instance.LoadLevel("Main",1.0f);
		}
	}
}
