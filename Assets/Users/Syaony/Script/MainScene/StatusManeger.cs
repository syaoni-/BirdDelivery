using UnityEngine;
using System.Collections;

public class StatusManeger : SingletonMonoBehaviour<StatusManeger> {

	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}


	public enum GameStatus{
		START,
		DIRECTION,
		ANGLE,
		POWER,
		FLY,
		FLYING,
		LANDING,
		FINISH
	}

	public static GameStatus gameState;

	// Use this for initialization
	void Start () {
		gameState = GameStatus.START;
	}

}
