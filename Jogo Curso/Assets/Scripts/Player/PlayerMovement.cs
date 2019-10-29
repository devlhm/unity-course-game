using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private bool isLookLeft;

	private Rigidbody2D playerRb;
	// Use this for initialization
	void Start () {
		playerRb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");

		playerRb.velocity = new Vector2 (h * speed, playerRb.velocity.y);

		if (isLookLeft && h > 0) {
			Flip ();
		} else if (!isLookLeft && h < 0) {
			Flip ();
		}

		if (Input.GetButtonDown ("Jump")) {

			playerRb.AddForce (new Vector2 (0, jumpForce));
		}
	}

	void Flip () {
		isLookLeft = !isLookLeft;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
}