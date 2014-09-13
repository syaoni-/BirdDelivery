using UnityEngine;
using System.Collections;

public class GUIManeger : MonoBehaviour {

	public GameObject directionArrow;

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

		angleX = 10;
		angleY = 50;
		angleW = 50;
		angleH = 50;

		powerX = 10;
		powerY = 100;
		powerW = 50;
		powerH = 200;
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnGUI(){
#if DEBUG_LOG
		GUI.Label(new Rect(10,10,100,100), "Direction : "+PlayerStatusManeger.playerDirection);
		GUI.Label (new Rect(10,20,100,100), "Angle : "+PlayerStatusManeger.playerAngle);
		GUI.Label(new Rect(10,30,100,100), "power : "+PlayerStatusManeger.playerJumpPow);
#endif
		GUI.DrawTexture(new Rect(powerX, powerY, powerW, powerH), powerGaugeBack);
		GUI.DrawTexture(new Rect(powerX, powerY, powerW, powerH*Mathf.Sin(PlayerStatusManeger.playerJumpPow)), powerGauge);

		GUIUtility.RotateAroundPivot(90 - PlayerStatusManeger.playerAngle, new Vector2(angleX+angleW/2, angleY+angleH));
		GUI.DrawTexture(new Rect(angleX, angleY, angleW, angleH), angleArrow);
	}

}
