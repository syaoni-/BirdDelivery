using UnityEngine;
using System.Collections;

public class PlayerStatusManeger : SingletonMonoBehaviour<PlayerStatusManeger> {

	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}


	public static int playerDirection;
	public static float playerAngle;
	public static float playerJumpPow;
	public static int playerDistanceToGoal;
	public static string targetName;
	private float jumpPowSpeed = 0.05f;
	private float angleSpeed = 0.025f;


	// Use this for initialization
	void Start () {
		playerDirection = 0;
		playerAngle = 0;
		playerJumpPow = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (StatusManeger.gameState) {
		case StatusManeger.GameStatus.DIRECTION:
			playerDirection++;
			if (playerDirection > 360){
				playerDirection = 0;
			}
			break;

		case StatusManeger.GameStatus.ANGLE:
			if (playerAngle < Mathf.PI/2) {
				playerAngle += angleSpeed;
			} else {
				playerAngle = -Mathf.PI/2;
			}
			break;

		case StatusManeger.GameStatus.POWER:
			if (playerJumpPow < Mathf.PI/2){
				playerJumpPow += jumpPowSpeed;
			} else {
				playerJumpPow = -Mathf.PI/2;
			}
			break;
		}
	}
}
