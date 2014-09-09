using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

	private float MaxPow = 100;
	private Vector3 jumpDirection;

	// Use this for initialization
	void Start () {
		jumpDirection = new Vector3(0,1,0);
	}
	
	// Update is called once per frame
	void Update () {
	}


	//State : DIRECTION
	//TODO
	void birdDirection(int dirValue){
		StartCoroutine("moveDirection",dirValue);
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
	void birdGetPow(float flyPow){
		StartCoroutine("birdFly",flyPow);
	}

	private IEnumerator birdFly(float flyPow){
		yield return new WaitForSeconds(3.0f); //wait 3 second
		Object.Destroy(GameObject.FindWithTag("Base")); //Base destroy 
		GameObject.FindWithTag("Earth").SendMessage("turnStart"); //Earth start turn
		gameObject.rigidbody.AddForce(jumpDirection * flyPow * MaxPow, ForceMode.VelocityChange);
	}


}
