using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterStat playerStats;
    // Use this for initialization
    public Health health;
    public Animator playerAnimator;
    public CharacterMovement characterMovement;
    void Awake () {
        //attack, defense, consitution, vitality
        playerStats = new CharacterStat(10, 10, 50, 50);
        health = GetComponent<Health>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (health.GetHealth() <= 0) {
            playerAnimator.SetBool("isDead", true);
            characterMovement.moveSpeed = 0;
        }
    }
}
