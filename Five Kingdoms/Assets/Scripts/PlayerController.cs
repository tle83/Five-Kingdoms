using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerRange;
	public float attackRange;
	public float playerDMG;

	private GameObject enemy;
	EnemyBasic enemyMob;
	private float enemyHP;
	public float enemyCurHP;

	private GameObject player;

	void Start () 
	{	
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyMob = enemy.GetComponent<EnemyBasic> ();
		enemyHP = enemyMob.enemyHP;
		enemyCurHP = enemyHP;

		player = GameObject.FindGameObjectWithTag ("Player");

	}
	

	void Update () 
	{
		if (enemy != null) {
			playerRange = Vector2.Distance (enemy.transform.position, player.transform.position);
		}
		isAttacking ();
	}

	void isAttacking()
	{
		//instance of left mouse button is clicked
		if (Input.GetMouseButtonDown (0) ) 
		{
			enemyCurHP -= playerDMG; 
		}
		//if enemy is still alive, update its HP
		if (enemyCurHP > 0) 
		{
			enemyHP = enemyCurHP;
		}
	}
}
