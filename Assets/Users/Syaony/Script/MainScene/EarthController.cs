using UnityEngine;
using System.Collections;

public class EarthController : MonoBehaviour {

	private bool isTurn = true;
	public GameObject playerParticle;


	//State : POWER
	void turnStart(){
		StartCoroutine("turn");
	}

	private IEnumerator turn(){

		int turnDirection = PlayerStatusManeger.playerDirection;
		float turnSpeed;
		float limitAngle = 0.1f;
		float angle = Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerAngle));

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
			Instantiate(playerParticle, info.transform.position, info.transform.rotation);
			Object.Destroy(info.gameObject);
			StatusManeger.gameState = StatusManeger.GameStatus.LANDING;
		}
	}


}
