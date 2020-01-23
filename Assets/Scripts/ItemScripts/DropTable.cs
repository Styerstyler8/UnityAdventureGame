using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable {
    public List<LootDrop> listOfDrop;

    public Item getDrop() {
        int tableRoll = Random.Range(0, 101);
        int weightSum = 0;
        foreach(LootDrop drop in listOfDrop) {
            weightSum += drop.probability;
            if(tableRoll < weightSum) {
                return ItemDatabase.instance.getItem(drop.itemName);

            }

        }
        return null;
    }
}

public class LootDrop {
    public string itemName;
    public int probability;

    public LootDrop(string itemName, int probability) {
        this.itemName = itemName;
        this.probability = probability;
    }
}