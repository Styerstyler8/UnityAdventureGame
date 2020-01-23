using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{

    public Item item;

    public Quest quest;

    public void setItem(Item item)
    {
        //Grabs item to show info
        this.item = item;

        setUpItemValues();
    }

    public void setUpItemValues()
    {
        //This gets child of UI panel for displaying item info. This will change the UI's text to the item's name
        if (quest != null)
        {
            this.transform.Find("ItemName").GetComponent<Text>().text = quest.questName;
            this.transform.Find("ItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryUI/icons/png/64px/Quest");
        }
        if (item != null && item.itemType == Item.ItemType.Craftable)
        {
            this.transform.Find("ItemName").GetComponent<Text>().text = item.name;
            this.transform.Find("ItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryUI/icons/png/64px/Crafting");
        }
        else if (item != null)
        {
            this.transform.Find("ItemName").GetComponent<Text>().text = item.name;
            this.transform.Find("ItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("InventoryUI/icons/png/64px/" + item.name);
            this.transform.Find("Quantity").GetComponent<Text>().text = "x" + item.quantity.ToString();
        }

    }

    //This means an item was selected and the details of item must be shown. Calls the method for given tab's inventory
    public void selectItemButton()
    {
        if (quest != null)
        {
            Inventory.instance.setQuestDetails(quest, GetComponent<Button>());
        }
        else
        {
            if (item == null)
            {
                return;
            }
            if (item.itemType == Item.ItemType.Consumable)
            {
                Inventory.instance.setConsumablesItemDetails(item, GetComponent<Button>());
            }
            if (item.itemType == Item.ItemType.Weapon)
            {
                Inventory.instance.setWeaponsItemDetails(item, GetComponent<Button>());
            }
            if (item.itemType == Item.ItemType.Resource)
            {
                Inventory.instance.setResourcesDetails(item, GetComponent<Button>());
            }
            if (item.itemType == Item.ItemType.Craftable)
            {
                Inventory.instance.setCraftablesDetails(item, GetComponent<Button>());
            }
        }
    }

    //Similar process for quests:
    public void setQuest(Quest quest)
    {
        //Grabs quest to show info
        this.quest = quest;

        setUpItemValues();
    }
}
