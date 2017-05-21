using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBasic: MonoBehaviour {

	public Transform target;
	PlayerHealth playerHP;

	private GameObject enemy;
	private Rigidbody2D enemyRB;
	private GameObject player;
	public Vector2 velocity;

	public float speed;
	public float attackRange;
	private float playerRange;
	public float attackDamage;
	private bool inRange;

	private bool isMoving;
	private Animator anim;

	private Slider hpSlider;

	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		player = GameObject.FindGameObjectWithTag ("Player");

		enemyRB = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
	}


	void Update () {
		isMoving = false;
		inRange = false;
		//the distance between the player and an enemy
		playerRange = Vector2.Distance (enemy.transform.position, player.transform.position);
		if (playerRange <= attackRange) {
			isMoving = true;
			inRange = true;
		}
		if (inRange == true) {
			velocity = new Vector2 ((transform.position.x - player.transform.position.x) * speed, (transform.position.y - player.transform.position.y) * speed);
			enemyRB.velocity = -velocity;
		} 
		if(inRange == false) {
			enemyRB.velocity = new Vector2 (0f, enemyRB.velocity.y);
			enemyRB.velocity = new Vector2 (enemyRB.velocity.x, 0f);
			enemyRB.velocity = new Vector2 (0f, 0f);
		}

		anim.SetBool ("isMoving", isMoving);
	}
}
