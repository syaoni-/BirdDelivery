using UnityEngine;
using System.Collections;

//status : TODO

public class GameControllerScript : MonoBehaviour {


	GameObject bird;
		
	public enum GameStatus{
		START,
		DIRECTION,
		ANGLE,
		POWER,
		FLY,
		LANDING,
		FINISH
	}

	public GameStatus state;

	public int playerDirection;
	public int playerAngle;
	public int playerJumpPow;


	// Use this for initialization
	void Start () {
	
		bird = GameObject.FindWithTag("Player");
		state = GameStatus.DIRECTION;

	}
	
	// Update is called once per frame
	void Update () {

		//GameStatus Function
		switch (state){
		case GameStatus.DIRECTION:
			directionDecide();
			break;

		case GameStatus.ANGLE:
			angleDecide();
			break;

		case GameStatus.POWER:
			powerDecide();
			break;

		case GameStatus.FLY:
			birdFly();
			break;

		case GameStatus.LANDING:
			birdLanding();
			break;

		default:
			break;
		}
	
	}



	//State : START
	//Game start function
	//TODO
	private void gameStart(){
		state = GameStatus.DIRECTION;
	}



	//State : DIRECTION
	//Derection decide function
	private void directionDecide(){

		playerDirection++;
		if (playerDirection > 360){
			playerDirection = 0;
		}

		if (Input.anyKeyDown){
			bird.SendMessage("birdDirection",playerDirection);
			GameObject.FindWithTag("Earth").SendMessage("getPlayerDirection",playerDirection);
			state = GameStatus.ANGLE;
		}
	}


	//State : ANGLE
	//Angle decide function
	//TODO
	private void angleDecide(){
		int rightAngle = 90;
		if (playerAngle < rightAngle){
			playerAngle++;
		} else {
			playerAngle = 0;
		}

		if (Input.anyKeyDown){
			GameObject.FindWithTag("Earth").SendMessage("getPlayerAngle",playerAngle);
			state = GameStatus.POWER;
		}
	}


	//State : POWER
	//Power decide function
	//TODO
	private void powerDecide(){

		playerJumpPow++;

		if (Input.anyKeyDown){
			bird.SendMessage("birdGetPow",Mathf.Abs(Mathf.Sin(playerJumpPow)));
			state = GameStatus.FLY;
		}
	}


	//State : FLY
	//Bird fly function
	//TODO
	private void birdFly(){
		state = GameStatus.LANDING;
	}


	//State : LANDING
	//Bird landing function
	//TODO
	private void birdLanding(){
		state = GameStatus.FINISH;
	}


	//State : FINISH
	//Game finish function
	//TODO
	private void gameFinish(){
	}


}