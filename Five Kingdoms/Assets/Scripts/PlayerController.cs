using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private Rigidbody2D rigidBody;

	private bool playerMoving;
	private Vector2 lastMove;

	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		playerMoving = false;
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			playerMoving = true;
			rigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, rigidBody.velocity.y);
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}
		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
		{
			playerMoving = true;
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime);
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}
		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) 
		{
			rigidBody.velocity = new Vector2 (0f, rigidBody.velocity.y);
		}
		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
		{
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 0f);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
		
	}
}
