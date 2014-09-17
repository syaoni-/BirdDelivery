using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetList : MonoBehaviour {

	public GameObject particlePrefab;

	List<GameObject> Targets = new List<GameObject>();

	// Use this for initialization
	void Start () {
		int maxTarget = 0;

		foreach(Transform child in transform) {
			Targets.Add(child.gameObject);
			maxTarget++;
		}

		int mainTarget = (int)Random.Range(0,maxTarget);
		Debug.Log(mainTarget);
		Debug.Log(maxTarget);
		Debug.Log(Targets[mainTarget].name);

		GameObject target = Targets[mainTarget];
		target.transform.localScale = target.transform.localScale * 2.5f;
		GameObject targetParticle = Instantiate(particlePrefab, target.transform.position, new Quaternion(0,0,0,1)) as GameObject;
		targetParticle.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
