using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float currentHP;
	public Slider hpSlider;
	public Image DMG;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 1.0f);

	PlayerController playerMovement;
	bool isDead;
	bool damaged;
	private GameObject player;
	private GameObject enemy;

	EnemyBasic enemyMob;
	private float attackDamage;

	void Start () {
		playerMovement = GetComponent<PlayerController> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyMob = enemy.GetComponent<EnemyBasic> ();
		attackDamage = enemyMob.attackDamage;

		hpSlider = GameObject.Find ("HPslider").GetComponent<Slider>();

		currentHP = hpSlider.value;
	}

	void Update () 	{
		if (damaged) {
			DMG.color = flashColor;
		} else {
			DMG.color = Color.Lerp (DMG.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(float amount){
		damaged = true;
		if (damaged == true) {
			currentHP -= attackDamage;
		}
		hpSlider.value = currentHP;
		Debug.Log (currentHP);
		if (currentHP <= 0 && !isDead) {
			Death ();
			Debug.Log ("DIED");
		}
	}

	void Death(){
		isDead = true;
		playerMovement.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == enemy) {
			TakeDamage (attackDamage);
		}
	}
}
