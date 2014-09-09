using UnityEngine;
using System.Collections;

public class CalManeger : MonoBehaviour {

	public static float getTurnX(float direction){
		float rightAngle = 90.0f;
		if (0 <= direction && direction < rightAngle*2){
			return direction/rightAngle - 1.0f;
		} else {
			return -direction/rightAngle + 3.0f;
		}
	}
	
	public static float getTurnZ(float direction){
		float rightAngle = 90;
		if (0 <= direction && direction < rightAngle){
			return direction/rightAngle;
		} else if (rightAngle <= direction && direction < rightAngle*3) {
			return -direction/rightAngle + 2.0f;
		} else {
			return direction/rightAngle - 4.0f;
		}
	}
}
