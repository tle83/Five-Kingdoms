using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic: MonoBehaviour {

	public Transform target;
	PlayerHealth playerHP;
	EnemyHealth enemyHP;

	private GameObject enemy;
	private GameObject player;
	public Vector2 velocity;

	public float speed;
	public float attackRange;
	public int attackDamage;
	public float attackCycle = 0.5f;

	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	void Update () {
		attackRange = Vector2.Distance (enemy.transform.position, player.transform.position);
		if (attackRange <= 15f) {
			velocity = new Vector2 ((transform.position.x - player.transform.position.x) * speed, (transform.position.y - player.transform.position.y) * speed);
			GetComponent<Rigidbody2D> ().velocity = -velocity;
		}
	}
}
