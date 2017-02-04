using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

	public Transform _target;
	public float _padding;
	
	// Update is called once per frame
	void Update () {
		if (_target.position.x > transform.position.x - _padding) {
			Vector3 cameraPosition = transform.position;
			cameraPosition.x = _target.position.x + _padding;
			transform.position = cameraPosition;
		}
	}
}
