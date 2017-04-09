using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int initialHP = 100;
	public int currentHP;
	public Slider hpSlider;
	public Image DMG;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

	PlayerController playerMovement;
	bool isDead;
	bool damaged;

	// Use this for initialization
	void Start () {
		playerMovement = GetComponent<PlayerController> ();

		currentHP = initialHP;
	}
	
	// Update is called once per frame
	void Update () 	{
		if (damaged) {
			DMG.color = flashColor;
		} else {
			DMG.color = Color.Lerp (DMG.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount){
		damaged = true;
		currentHP -= amount;
		hpSlider.value = currentHP;
		if (currentHP <= 0 && !isDead) {
			Death ();
		}
	}

	void Death(){
		isDead = true;
		playerMovement.enabled = false;
	}
}
