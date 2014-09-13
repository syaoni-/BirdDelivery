﻿using UnityEngine;
using System.Collections;

public class EarthController : MonoBehaviour {

	private int turnDirection;
	private bool isTurn;


	//State : DIRECTION
	void getPlayerDirection(int playerDirection){
		turnDirection = playerDirection;
		isTurn = true;
	}


	//State : ANGLE
	//TODO
	void getPlayerAngle(int playerAngle){
	}


	//State : POWER
	void turnStart(){
		StartCoroutine("turn");
	}

	private IEnumerator turn(){

		int turnDirection = PlayerStatusManeger.playerDirection;
		float turnSpeed;
		float limitAngle = 0.01f;
		float angle = Mathf.Sin(PlayerStatusManeger.playerAngle);

		if (angle < limitAngle){
			turnSpeed = limitAngle;
		} else {
			turnSpeed = limitAngle/angle;
		}

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
