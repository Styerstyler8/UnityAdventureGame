//This script is not used anymore as the way to deal with items was changed
//Leaving here for reference to more information how to use unity and may use for future use


/*
using UnityEngine;
using UnityEngine.UI; //Used to update UI sprites and item sprites

//This class is used to keep track of everything for a specific item slot
public class InventorySlot : MonoBehaviour {

    //Referance to item sprite and slot remove button
    public Image icon;
    public Button removeButton;

    //Reference to amount in inventory
    public Text itemCount;

    //Keeps track of item in slot
    Item item;

    //Item in specific slot is added and set to item
    public void addItem(Item newItem)
    {
        item = newItem;

        //Changes the icon to item's icon and enables it so its visible (same with remove button)
        //icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    //Remove item
    public void clearSlot()
    {
        item = null;

        //Remove sprite from inventory and remove remove button
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void removeItem()
    {
        //Calls inventory to remove
        Inventory.instance.Remove(item);
    }
	
    public void useItem()
    {
        //Actually use item when clicked
        if(item != null)
        {
            item.use();
        }
    }
}
*/