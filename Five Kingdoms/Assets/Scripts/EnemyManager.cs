using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
	public PlayerHealth playerHP;
	public GameObject enemy;
	public float spawnRate;
	public float spawnLimit;
	public float currentSpawns = 0.0f;
	public Transform[] spawnPoints;

	void Start () {
		//call the spawn function after a delay of spawnRate then call again after the same amount of time
		InvokeRepeating ("Spawn", spawnRate, spawnRate);	
	}

	void Spawn(){
		//test if the player has any health
		//also text if the current amount of spawns on the map is under the spawn limit
		if (playerHP.currentHP <= 0.0f || currentSpawns >= spawnLimit) {
			//stop the function 
			return;
		}

		//increment current spawn count to match the ones on the map
		currentSpawns++;

		//find a random index
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

		//create an instance of the enemy prefab at the selected spawn point
		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
