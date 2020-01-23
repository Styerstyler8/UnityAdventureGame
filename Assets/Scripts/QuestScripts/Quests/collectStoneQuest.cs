using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an example of a quest, where the player has to pick up 3 wood
public class collectStoneQuest : Quest
{

    private void Start()
    {

        //Simple way to make a quest, just fill out all properties and add to objective list
        questName = "Collect 4 stone";
        questDescription = "Get rid of those goblins and collect the stone!";

        itemReward = "Sword_2H";

        experienceAward = 200;

        int currentAmount = 0;

        objectives.Add(new CollectObjective(this, "Stone", questDescription, false, currentAmount, 4));

        objectives.ForEach(g => g.initialization()); //Loop through all objectives for quest and initialize them
    }

    private void addToUI()
    {
        Inventory.instance.addSword();
        Inventory.instance.addQuest(this);
    }

}