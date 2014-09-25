using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetList : MonoBehaviour {

	private Vector3 playerStartPos;

	private GameObject target;
	public GameObject particlePrefab;
	public GameObject targetDirection;
	public GameObject targetSignPrefab;
	private GameObject targetArrow;

	List<GameObject> Targets = new List<GameObject>();

	// Use this for initialization
	void Start () {

		playerStartPos = GameObject.FindWithTag("Player").transform.position;

		int maxTarget = 0;

		foreach(Transform child in transform) {
			Targets.Add(child.gameObject);
			maxTarget++;
		}

		int mainTarget = (int)Random.Range(0,maxTarget);
		Debug.Log(mainTarget);
		Debug.Log(maxTarget);
		Debug.Log(Targets[mainTarget].name);

		target = Targets[mainTarget];
		target.tag = "MainTarget";
		PlayerStatusManeger.targetName = target.name;
		target.transform.localScale = target.transform.localScale * 2.5f;
		GameObject targetParticle = Instantiate(particlePrefab, target.transform.position, target.transform.rotation) as GameObject;
		targetParticle.transform.parent = target.transform;

		targetArrow = Instantiate(targetDirection, playerStartPos, this.transform.rotation) as GameObject;
		targetArrow.transform.LookAt(target.transform);
		targetArrow.transform.rotation = new Quaternion(0,targetArrow.transform.rotation.y, 0, 1);
		targetArrow.transform.position += targetArrow.transform.forward * 100;
		GameObject targetSign = Instantiate(targetSignPrefab, target.transform.position + target.transform.up*200.0f, target.transform.rotation) as GameObject;
		targetSign.transform.parent = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float restDistance = 500.0f * Vector3.Angle(playerStartPos, target.transform.position);
		PlayerStatusManeger.playerDistanceToGoal = (int)restDistance;

		switch (StatusManeger.gameState) {
		case StatusManeger.GameStatus.ANGLE:
			Object.Destroy(targetArrow);
			break;

		default:
			break;
		}
	}
}