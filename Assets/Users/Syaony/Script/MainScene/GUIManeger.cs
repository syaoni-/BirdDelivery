using UnityEngine;
using System.Collections;

public class GUIManeger : MonoBehaviour {

	public GameObject directionArrow;
	private GameObject targetDirectionArrow;

	public Texture angleArrow;
	private float angleX;
	private float angleY;
	private float angleW;
	private float angleH;

	public Texture powerGauge;
	public Texture powerGaugeBack;
	private float powerX;
	private float powerY;
	private float powerW;
	private float powerH;

	// Use this for initialization
	void Start () {
		Instantiate(directionArrow,transform.position,transform.rotation);

		float screenWidth = Screen.width/10;
		float screenHeight = Screen.height/10;

		angleX = screenWidth*3;
		angleY = screenHeight*2;
		angleW = screenWidth*2;
		angleH = screenHeight*3;

		powerX = screenWidth;
		powerY = screenHeight*3;
		powerW = screenWidth;
		powerH = screenHeight*5;
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnGUI(){
#if DEBUG_LOG
		GUI.Label(new Rect(10,10,100,100), "Direction : "+PlayerStatusManeger.playerDirection);
		GUI.Label (new Rect(10,20,100,100), "Angle : "+PlayerStatusManeger.playerAngle);
		GUI.Label(new Rect(10,30,100,100), "power : "+Mathf.Sin(PlayerStatusManeger.playerJumpPow));
		GUI.Label(new Rect(10,50,100,100), "Distance : "+PlayerStatusManeger.playerDistanceToGoal);
		GUI.Label(new Rect(400,10,100,100), "Target : "+PlayerStatusManeger.targetName);
#endif
		switch (StatusManeger.gameState) {

		case StatusManeger.GameStatus.ANGLE:
			if (PlayerStatusManeger.playerDirection < 180) {
			GUIUtility.RotateAroundPivot(90 - 90 * Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerAngle)), new Vector2(angleX+angleW/2, angleY+angleH));
			} else {
				GUIUtility.RotateAroundPivot(270 + 90 * Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerAngle)), new Vector2(angleX+angleW/2, angleY+angleH));
			}
			GUI.DrawTexture(new Rect(angleX, angleY, angleW, angleH), angleArrow);
			break;

		case StatusManeger.GameStatus.POWER:
			GUI.DrawTexture(new Rect(powerX, powerY, powerW, powerH), powerGauge);
			GUI.DrawTexture(new Rect(powerX, powerY, powerW, powerH - powerH*Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerJumpPow))),powerGaugeBack);
			break;

		default:
			break;
		}
	}

}