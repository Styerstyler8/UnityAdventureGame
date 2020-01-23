using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    //Handles items and anything player does with item, this creates a type of event
    public delegate void ItemEventHandler(Item item);

    //Similar to above but for quests:
    public delegate void QuestEventHandler(Quest quest);

    //Actual event for when item added to inventory
    public static event ItemEventHandler OnItemAddedToInventory;

    //Event for when quest added to inventory
    public static event QuestEventHandler OnQuestAddedToInventory;

    //This allows inventory UI to know information of item, can display item stats etc.
    public static void ItemAddedToInventory(Item item)
    {
        if (item.name != "TESTITEM")
        {
            OnItemAddedToInventory(item);
        }
        else
        {
            Debug.Log("We are testing adding items to inventory");
        }
    }

    //Update UI about quest:
    public static void questAddedToInventory(Quest quest)
    {
        OnQuestAddedToInventory(quest);
    }

}