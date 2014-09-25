using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private GameObject player;
	private Vector3 targetPos;
	private Vector3 lookPos;

	private Vector3 dPos;
	private float speed = 0.03f;
	
	private float horizontalAngle = 150.0f;
	private float highAngle = 300.0f;
	private float radius = 100.0f;
	private float backCameraPos = 100.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		player = GameObject.FindWithTag("Player");

		if (player != null) {
			transform.LookAt(lookPos);
			lookPos = player.transform.position;
		}

		switch (StatusManeger.gameState) {
		case StatusManeger.GameStatus.STARTTALK:
			break;

		case StatusManeger.GameStatus.TARGETSCENE:
			GameObject target = GameObject.FindWithTag("MainTarget");
			targetPos = target.transform.position + target.transform.up * 100.0f + target.transform.forward * 500.0f;
			dPos = (targetPos - this.transform.position) * speed;
			this.transform.position += dPos;
			lookPos = target.transform.position;
			break;

		case StatusManeger.GameStatus.START:
			break;

		case StatusManeger.GameStatus.DIRECTION:
			//High angle camera
			targetPos = player.transform.position + player.transform.up * highAngle;
			dPos = (targetPos - this.transform.position) * speed;
			this.transform.position += dPos;
			break;
			 
		case StatusManeger.GameStatus.ANGLE:
			Quaternion playerRotation = player.transform.rotation;
			targetPos = player.transform.position + new Vector3(Mathf.Cos(playerRotation.y + horizontalAngle) * radius, 10, Mathf.Sin(playerRotation.y + horizontalAngle) * radius);
			dPos = (targetPos - this.transform.position) * speed;
			this.transform.position += dPos;
			lookPos += player.transform.forward * 30.0f;
			break;

		case StatusManeger.GameStatus.POWER:
			lookPos += player.transform.forward * 30.0f;
			break;

		case StatusManeger.GameStatus.FLY:
			targetPos = player.transform.position + (-player.transform.forward * backCameraPos) + new Vector3(0,30,0);
			dPos = (targetPos - this.transform.position) * speed;
			this.transform.position += dPos;
			break;

		case StatusManeger.GameStatus.FLYING:
			this.transform.position = player.transform.position + (-player.transform.forward * backCameraPos) + new Vector3(0,30,0);
			break;

		case StatusManeger.GameStatus.LANDING:
			break;

		case StatusManeger.GameStatus.FINISH:
			break;
			
		default:
			break;
		}

	}
}
