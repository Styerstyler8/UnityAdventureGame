using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePill : MonoBehaviour {

	public GameObject player;

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.name == "ThirdPersonController")
		{
			print("Player has entered");
			player.GetComponent<Experience>().AddXP(20);

			this.gameObject.SetActive(false);
		}
	}
}
