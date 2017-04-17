using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject menu;
	private bool isShowing;

	void Start () {
		
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			isShowing = !isShowing;
			menu.SetActive (isShowing);
		}
	}
}
