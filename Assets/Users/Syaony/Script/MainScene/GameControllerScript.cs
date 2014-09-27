using UnityEngine;
using System.Collections;

//status : TODO

public class GameControllerScript : SingletonMonoBehaviour<GameControllerScript> {

	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}


	GameObject bird;

	public AudioClip parameterSE;

	// Use this for initialization
	void Start () {
		bird = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//GameStatus Function
		switch (StatusManeger.gameState){
		case StatusManeger.GameStatus.STARTTALK:
			gameStartTalk();
			break;

		case StatusManeger.GameStatus.TARGETSCENE:
			targetScene();
			break;

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

		case StatusManeger.GameStatus.FINISH:
			gameFinish();
			break;
		default:
			break;
		}
	}



	//State : STARTTALK
	//Game start function
	//TODO
	private void gameStartTalk(){
		StatusManeger.gameState = StatusManeger.GameStatus.TARGETSCENE;
	}

	//State : TARGETSECENE
	//Game start function
	//TODO
	private void targetScene(){
		if (Input.anyKeyDown) {
			StatusManeger.gameState = StatusManeger.GameStatus.START;
		}
	}

	//State : START
	//Game start function
	//TODO
	private void gameStart(){
		StatusManeger.gameState = StatusManeger.GameStatus.DIRECTION;
	}



	//State : DIRECTION
	//Derection decide function
	private void directionDecide(){
		if (Input.anyKeyDown){
			audio.PlayOneShot(parameterSE);
			//bird.SendMessage("birdDirection");
			GameObject.FindWithTag("Player").SendMessage("birdDirection");
			Debug.Log ("test");
			StatusManeger.gameState = StatusManeger.GameStatus.ANGLE;
			Debug.Log(StatusManeger.gameState);
		}
	}


	//State : ANGLE
	//Angle decide function
	//TODO
	private void angleDecide(){
		if (Input.anyKeyDown){
			audio.PlayOneShot(parameterSE);
			Debug.Log("fffff");
			StatusManeger.gameState = StatusManeger.GameStatus.POWER;
		}
	}


	//State : POWER
	//Power decide function
	//TODO
	private void powerDecide(){

		if (Input.anyKeyDown){
			audio.PlayOneShot(parameterSE);
			//bird.SendMessage("birdGetPow");
			GameObject.FindWithTag("Player").SendMessage("birdGetPow");
			StatusManeger.gameState = StatusManeger.GameStatus.FLY;
		}
	}


	//State : FLY
	//Bird fly function
	//TODO
	private void birdFly(){
		//StatusManeger.gameState = StatusManeger.GameStatus.LANDING;
	}


	//State : LANDING
	//Bird landing function
	//TODO
	private void birdLanding(){
		StatusManeger.gameState = StatusManeger.GameStatus.FINISH;
	}


	//State : FINISH
	//Game finish function
	//TODO
	private void gameFinish(){
		StatusManeger.gameState = StatusManeger.GameStatus.RESULT;
	}


}