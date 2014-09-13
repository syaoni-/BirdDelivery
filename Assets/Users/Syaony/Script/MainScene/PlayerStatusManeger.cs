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
	public static int playerAngle;
	public static float playerJumpPow;
	private float jumpPowSpeed = 0.1f;


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
			int rightAngle = 90;
			if (playerAngle < rightAngle){
				playerAngle++;
			} else {
				playerAngle = 0;
			}
			break;

		case StatusManeger.GameStatus.POWER:
			playerJumpPow += jumpPowSpeed;
			break;
		}
	}
}
