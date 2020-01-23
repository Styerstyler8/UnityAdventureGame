using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesController : MonoBehaviour {
    //Reference to character stats later, ex. CharacterStats stats
    public CharacterStat stats;

    void Start () {
        //Set character stats to character's stats
        stats = GetComponent<Player>().playerStats;
    }

    //This would instantiate object if needed for effects and consume 
    public void consumeItem(Item item)
    {
        //Instantiate object so it can perform actions
        GameObject itemSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.name));

        //If item effects stats, call consume method for stats, otherwise normal consume
        if (item.effectsStats)
        {
            itemSpawn.GetComponent<IConsumables>().consume(stats);
        }
        else
        {
            itemSpawn.GetComponent<IConsumables>().consume();
        }

        //Remove from inventory:
        Inventory.instance.Remove(item);

        //Destroy item after interacting with it
        Destroy(itemSpawn);
    }
	
}
