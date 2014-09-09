using UnityEngine;
using System.Collections;

public class GUIManeger : MonoBehaviour {

	GameControllerScript gameController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameController = GetComponent<GameControllerScript>();
	}


	void OnGUI(){
#if DEBUG_LOG

		switch (gameController.state) {
		case GameControllerScript.GameStatus.DIRECTION:
			GUI.Label(new Rect(10,10,100,100), "Direction : "+gameController.playerDirection);
			break;

		case GameControllerScript.GameStatus.ANGLE:
			GUI.Label (new Rect(10,20,100,100), "Angle : "+gameController.playerAngle);
			break;

		case GameControllerScript.GameStatus.POWER:
			GUI.Label(new Rect(10,30,100,100), "power : "+Mathf.Sin(gameController.playerJumpPow));
			break;

		default:
			break;
		}
#endif
	}

}
