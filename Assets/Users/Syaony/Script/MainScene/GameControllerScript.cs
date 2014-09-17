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
		state = GameStatus.START;


	}
	
	// Update is called once per frame
	void Update () {

		//GameStatus Function
		switch (StatusManeger.gameState){
		case StatusManeger.GameStatus.START:
			gameStart();
			break;

		case StatusManeger.GameStatus.DIRECTION:
			directionDecide();
			break;

		case StatusManeger.GameStatus.ANGLE:
			angleDecide();
			break;

		case StatusManeger.GameStatus.POWER:
			powerDecide();
			break;

		case StatusManeger.GameStatus.FLY:
			birdFly();
			break;

		case StatusManeger.GameStatus.LANDING:
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
		StatusManeger.gameState = StatusManeger.GameStatus.DIRECTION;
	}



	//State : DIRECTION
	//Derection decide function
	private void directionDecide(){
		if (Input.anyKeyDown){
			bird.SendMessage("birdDirection",playerDirection);
			//GameObject.FindWithTag("Earth").SendMessage("getPlayerDirection",playerDirection);
			StatusManeger.gameState = StatusManeger.GameStatus.ANGLE;
		}
	}


	//State : ANGLE
	//Angle decide function
	//TODO
	private void angleDecide(){
		if (Input.anyKeyDown){
			state = GameStatus.POWER;
			StatusManeger.gameState = StatusManeger.GameStatus.POWER;
		}
	}


	//State : POWER
	//Power decide function
	//TODO
	private void powerDecide(){

		if (Input.anyKeyDown){
			bird.SendMessage("birdGetPow",Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerJumpPow)));
			state = GameStatus.FLY;
			StatusManeger.gameState = StatusManeger.GameStatus.FLY;
		}
	}


	//State : FLY
	//Bird fly function
	//TODO
	private void birdFly(){
		state = GameStatus.LANDING;
		StatusManeger.gameState = StatusManeger.GameStatus.LANDING;
	}


	//State : LANDING
	//Bird landing function
	//TODO
	private void birdLanding(){
		state = GameStatus.FINISH;
		StatusManeger.gameState = StatusManeger.GameStatus.FINISH;
	}


	//State : FINISH
	//Game finish function
	//TODO
	private void gameFinish(){
	}


}