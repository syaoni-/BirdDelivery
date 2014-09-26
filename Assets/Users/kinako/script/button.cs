using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	public GUISkin skin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
				GUI.skin = skin;
				Rect boxRect = new Rect (Screen.width / 3, Screen.height / 3, Screen.width / 3, Screen.height / 3);
				Rect beginRect = boxRect;
				beginRect.x += 20;
				beginRect.y += 50;
				beginRect.width -= 40;
				beginRect.height -= 80;
		GUILayout.Label("メインメニュー");




		}
}
