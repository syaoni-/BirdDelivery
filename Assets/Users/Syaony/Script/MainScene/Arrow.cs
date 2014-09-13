using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	private GameObject centerObj;
	private GameObject gameController;
	private GameControllerScript gameState;

	// Use this for initialization
	void Start () {
		centerObj = GameObject.FindWithTag("Player");
		transform.position = centerObj.transform.position + centerObj.transform.forward + centerObj.transform.up;
	}
	
	// Update is called once per frame
	void Update () {
		switch (StatusManeger.gameState){
		case StatusManeger.GameStatus.DIRECTION:
			transform.RotateAround(centerObj.transform.position, centerObj.transform.up, 1);
			break;
		
		case StatusManeger.GameStatus.FLY:
			Object.Destroy(gameObject);
			break;

		default:
			break;

		}
	}

}
