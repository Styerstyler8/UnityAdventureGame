using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {

	public GameObject player;

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.name == "ThirdPersonController")
		{
			print("Player has entered");
			player.GetComponent<Health>().Heal(20);
		}
	}

}
