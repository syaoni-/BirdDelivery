using UnityEngine;
using System.Collections;

public class DirectionArrow : MonoBehaviour {

	private GameObject centerObj;
	private GameObject gameController;
	private GameControllerScript gameState;
	
	// Use this for initialization
	void Start () {
		centerObj = GameObject.FindWithTag("Player");
		transform.position = centerObj.transform.position + centerObj.transform.forward*gameObject.transform.localScale.x*1.2f + centerObj.transform.up;
		transform.rotation = new Quaternion(0,45,45,1);
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
