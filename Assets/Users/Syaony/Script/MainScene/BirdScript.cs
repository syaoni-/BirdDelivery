using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	private Vector3 earthPos;
	private float gravity = 0.1f;

	private float MaxPow = 100;
	private Vector3 jumpDirection;

	private Animator anim;

	// Use this for initialization
	void Start () {
		earthPos = GameObject.FindWithTag("Earth").transform.position;

		jumpDirection = new Vector3(0,1,0);
		anim = GetComponent<Animator>();
		anim.SetBool("isFly",false);
	}
	
	// Update is called once per frame
	void Update () {
		switch (StatusManeger.gameState){
		case StatusManeger.GameStatus.FLYING:
			transform.rigidbody.AddForce(gravity * (earthPos - transform.position), ForceMode.Force);
			break;

		default:
			break;
		}
	}


	//State : DIRECTION
	void birdDirection(){
		StartCoroutine("moveDirection",PlayerStatusManeger.playerDirection);
	}

	private IEnumerator moveDirection(float dirValue){
		while (true){
			Quaternion q = Quaternion.Euler(0,dirValue,0);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime*1);
			yield return 0;
		}
	}


	//State : POWER
	//TODO
	void birdGetPow(){
		//StartCoroutine("birdFly",Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerJumpPow)));
		Invoke("birdFly",3.0f);
	}

	private void birdFly(){
		Object.Destroy(GameObject.FindWithTag("Base")); //Base destroy 
		GameObject.FindWithTag("Earth").SendMessage("turnStart"); //Earth start turn
		gameObject.rigidbody.AddForce(jumpDirection * Mathf.Abs(Mathf.Sin(PlayerStatusManeger.playerJumpPow)) * MaxPow, ForceMode.VelocityChange);
		anim.SetBool("isFly",true);
		StatusManeger.gameState = StatusManeger.GameStatus.FLYING;
	}


}
