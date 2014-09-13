using UnityEngine;
using System.Collections;

public class AngleArrow : MonoBehaviour {

	private GameObject mainCamera;
	private Vector3 mainCameraPos;

	// Use this for initialization
	void Start () {
		/*mainCamera = GameObject.FindWithTag("MainCamera");
		mainCameraPos = mainCamera.transform.position;
		transform.position = mainCameraPos + new Vector3(1,-1,-5);*/
	}
	
	// Update is called once per frame
	void Update () {
		switch (StatusManeger.gameState){
		case StatusManeger.GameStatus.ANGLE:
			Quaternion mainCameraRotate = GameObject.FindWithTag("MainCamera").transform.rotation;
			transform.rotation = new Quaternion(mainCameraRotate.x,-mainCameraRotate.y,mainCameraRotate.z, 1);
			break;
			
		case StatusManeger.GameStatus.FLY:
			Object.Destroy(gameObject);
			break;
			
		default:
			break;
			
		}
	}
}
