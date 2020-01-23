using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextAppear : MonoBehaviour {

	public GameObject healthText;

	public void Appear() {
		print ("mouse has entered!");
		healthText.GetComponent<Text> ().enabled = true;
	}

	public void Dissapear() {
		healthText.GetComponent<Text> ().enabled = false;
	}
}
