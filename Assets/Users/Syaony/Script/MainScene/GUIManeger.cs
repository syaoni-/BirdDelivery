using UnityEngine;
using System.Collections;

public class GUIManeger : MonoBehaviour {

	public GameObject directionArrow;
	private GameObject targetDirectionArrow;

	private float screenWidth;
	private float screenHeight;

	public Texture angleArrow;
	public Texture powerGauge;
	public Texture powerGaugeBack;
	public Texture resultBack;
	public Texture[] resultCharacters = new Texture[5];
	private int resultCharacter;

	public GUISkin numberSkin;
	public GUISkin textSkin;
	public GUISkin retrySkin;
	public GUISkin topSkin;

	// Use this for initialization
	void Start () {
		Instantiate(directionArrow,transform.position,transform.rotation);

		screenWidth = Screen.width/10;
		screenHeight = Screen.height/10;

		resultCharacter = (int)Random.Range(0,5);
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
		GUI.skin = textSkin;
		GUI.Label(new Rect(screenWidth*3,screenHeight/3*2, screenWidth*3, screenHeight*2), ""+PlayerStatusManeger.targetName+" : ");
		GUI.skin = numberSkin;
		GUI.Label(new Rect(screenWidth*6,screenHeight, screenWidth*3, screenHeight), ""+PlayerStatusManeger.playerDistanceToGoal+"km");

		switch (StatusManeger.gameState) {

		case StatusManeger.GameStatus.ANGLE:
			float angleX = screenWidth*3;
			float angleY = screenHeight*2;
			float angleW = screenWidth*2;
			float angleH = screenHeight*3;

			if (PlayerStatusManeger.playerDirection < 180) {
			GUIUtility.RotateAroundPivot(90 - 90 * Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerAngle)), new Vector2(angleX+angleW/2, angleY+angleH));
			} else {
				GUIUtility.RotateAroundPivot(270 + 90 * Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerAngle)), new Vector2(angleX+angleW/2, angleY+angleH));
			}
			GUI.DrawTexture(new Rect(angleX, angleY, angleW, angleH), angleArrow);
			break;

		case StatusManeger.GameStatus.POWER:
			GUI.DrawTexture(new Rect(screenWidth, screenHeight*3, screenWidth, screenHeight*5), powerGauge);
			GUI.DrawTexture(new Rect(screenWidth, screenHeight*3, screenWidth, screenHeight*5*(1 - Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerJumpPow)))),powerGaugeBack);
			break;

		case StatusManeger.GameStatus.RESULT:
			GUI.DrawTexture(new Rect(screenWidth, screenHeight, screenWidth*8, screenHeight*8), resultBack);
			GUI.DrawTexture(new Rect(screenWidth, screenHeight, screenWidth*8, screenHeight*8), resultCharacters[resultCharacter]);
			//GUI.DrawTexture(new Rect(screenWidth*2, screenHeight*8, screenWidth*3, screenHeight*2), retryTexture);
			//GUI.DrawTexture(new Rect(screenWidth*6, screenHeight*8, screenWidth*3, screenHeight*2), retryTexture);
			GUI.skin = textSkin;
			GUI.Label(new Rect(screenWidth*3,screenHeight*4, screenWidth*3, screenHeight*2), "Score");
			GUI.skin = numberSkin;
			GUI.Label(new Rect(screenWidth*3,screenHeight*5, screenWidth*3, screenHeight*2), ""+PlayerStatusManeger.playerDistanceToGoal+"km");

			GUI.skin = retrySkin;
			if (GUI.Button(new Rect(screenWidth, screenHeight*8, screenWidth*3, screenHeight*2),"")) {
				Application.LoadLevel("Main");
			}

			GUI.skin = topSkin;
			if (GUI.Button(new Rect(screenWidth*6, screenHeight*8, screenWidth*3, screenHeight*2), "")) {
				StatusManeger.gameState = StatusManeger.GameStatus.START;
				Application.LoadLevel("title");
			}
			break;

		default:
			break;
		}
	}

}