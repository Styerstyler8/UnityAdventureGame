/*
 * Additional task if enough time
 * Would have to have listener for when an enemy dies
 * which would pass enemy ID
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a base class for objectives that make the player fight. ex. kill 5 enemies
//Implement later when we have scripts attached to enemies
public class FightObjective : Objective {

    public int enemyID;

	public FightObjective(int enemyID_, string desc, bool complet, int curr, int endAm){
        enemyID = enemyID_;
        description = desc;
        completed = complet;
        currProgress = curr;
        endAmount = endAm;
    }

    public override void initialization(){
        base.initialization();
    }

    void enemyDead(Enemy enemy){
        
    }
        
}
*/