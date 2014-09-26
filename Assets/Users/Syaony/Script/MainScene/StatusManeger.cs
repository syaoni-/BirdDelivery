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
		STARTTALK,
		TARGETSCENE,
		START,
		DIRECTION,
		ANGLE,
		POWER,
		FLY,
		FLYING,
		LANDING,
		FINISH,
		RESULT
	}

	public static GameStatus gameState;

	// Use this for initialization
	void Start () {
		gameState = GameStatus.STARTTALK;
	}

}
