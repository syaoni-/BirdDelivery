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
		LANDING,
		FINISH
	}

	public static GameStatus gameState;

	// Use this for initialization
	void Start () {
		gameState = GameStatus.START;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
