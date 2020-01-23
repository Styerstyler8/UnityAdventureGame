using UnityEngine;

public class ItemPickup : Interactables {

    //Allows accessing features of items, such as names
    public Item item;

    public string itemName;

    public override void interact()
    {
        base.interact();

        pickUp();
    }

    void pickUp()
    {
        Item itemPickup = ItemDatabase.instance.getItem(itemName);

        //Add to inventory
        //If we didnt create instance in inventory class, would have to write long code
        //Now can just use
        if(item != null)
        {
            Inventory.instance.Add(item.name);
        }
        else
        {
            Inventory.instance.Add(itemPickup.name);
        }

        //Remove object from world
        Destroy(gameObject);
    }
}