using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be an objective for collecting a certain amount of items
public class CollectObjective : Objective {

    //itemName will be the name of the item needed to be collected
    public string itemName;

    //Constructor for collect objective
    public CollectObjective(Quest quest, string itemName, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.quest = quest;
        this.itemName = itemName;
        this.description = description;
        this.completed = completed;
        this.currProgress = currentAmount;
        this.endAmount = requiredAmount;
    }

    public override void initialization()
    {
        base.initialization();
        checkStartProgress();
        UIEventHandler.OnItemAddedToInventory += itemPickedUp; //Event caller that adds below method to check for items picked up
    }

    public void itemPickedUp(Item item)
    {
        if(item.name == this.itemName && !this.completed)
        {
            this.currProgress++;
            progress();
        }
    }

    //When quest is complete, remove items from inventory
    public override void removeQuestItems()
    {
        for(int i = 0; i < endAmount; i++)
        {
            Inventory.instance.Remove(ItemDatabase.instance.getItem(itemName));
        }
    }
}
