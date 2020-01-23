using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "ThirdPersonController")
        {
            print("Player has entered");
            player.GetComponent<Health>().TakeDamage(20);
        }
    }
}
