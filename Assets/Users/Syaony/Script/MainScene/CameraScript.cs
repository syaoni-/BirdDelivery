using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private Vector3 playerPosition;

	// Use this for initialization
	void Start () {
		playerPosition = GameObject.FindWithTag("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = GameObject.FindWithTag("Player").transform.position;
		transform.LookAt(playerPosition);
	}
}
