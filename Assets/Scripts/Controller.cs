using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	private Rigidbody2D _rigidBody;

	public float _moveSpeed;
	public float _jumpForce;
	public float _maxSpeed;

	// Use this for initialization
	void Start () {
		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0) {
			_rigidBody.AddForce (new Vector2 (_moveSpeed, 0));
		} else if (Input.GetAxis ("Horizontal") < 0) {
			_rigidBody.AddForce(new Vector2(-_moveSpeed, 0));
		}

		if (_rigidBody.velocity.x > _maxSpeed) {
			_rigidBody.velocity = new Vector2 (_maxSpeed, _rigidBody.velocity.y);
		} else if (_rigidBody.velocity.x < -_maxSpeed) {
			_rigidBody.velocity = new Vector2 (-_maxSpeed, _rigidBody.velocity.y);
		}

		if (Input.GetButtonDown ("Jump")) {
			_rigidBody.AddForce (new Vector2 (0, _jumpForce), ForceMode2D.Impulse);
		}
	}
}
