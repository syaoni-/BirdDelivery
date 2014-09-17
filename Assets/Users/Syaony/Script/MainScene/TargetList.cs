using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetList : MonoBehaviour {

	public ParticleSystem targetParticle;

	List<GameObject> targetList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		int maxTarget = 0;

		foreach(Transform child in transform) {
			targetList.Add(child.gameObject);
			maxTarget++;
		}

		int mainTarget = (int)Random.Range(0,maxTarget);
		Debug.Log(mainTarget);
		Debug.Log(mainTarget % maxTarget);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
