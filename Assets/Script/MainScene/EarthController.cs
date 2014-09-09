using UnityEngine;
using System.Collections;

public class EarthController : MonoBehaviour {

	private int turnDirection;
	private float turnSpeed;
	private float limitAngle;
	private bool isTurn;


	//State : DIRECTION
	void getPlayerDirection(int playerDirection){
		turnDirection = playerDirection;
		limitAngle = 0.1f;
		isTurn = true;
	}


	//State : ANGLE
	//TODO
	void getPlayerAngle(int playerAngle){
		float angle = Mathf.Sin(playerAngle);
		if (angle < limitAngle){
			turnSpeed = limitAngle;
		} else {
			turnSpeed = limitAngle/angle;
		}
	}


	//State : POWER
	void turnStart(){
		StartCoroutine("turn");
	}

	private IEnumerator turn(){
		float turnX = turnSpeed * CalManeger.getTurnX((float)turnDirection);
		float turnZ = turnSpeed * CalManeger.getTurnZ((float)turnDirection);

		//if collision plyaer, stop turn
		while (isTurn){
			transform.Rotate(turnX,0,turnZ);
			yield return 0;
		}
	}


	// if player collision earth, turn stop
	private void OnCollisionEnter(Collision info){
		if (info.gameObject.tag == "Player"){
			isTurn = false;
		}
	}


}
