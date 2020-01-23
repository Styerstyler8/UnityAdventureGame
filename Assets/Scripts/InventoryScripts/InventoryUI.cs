using UnityEngine;
using UnityEngine.UI;

//This class keeps track of inventory and updates it
public class InventoryUI : MonoBehaviour
{

    //Reference to entire inventory
    public GameObject inventoryUI;

    //Stores inventory in variable
    Inventory inventory;

    //Reference to inventoryUI panel, scrollArea for each tab's inventory
    public RectTransform weaponsInventoryPanel;
    public RectTransform weaponsScrollViewContent;
    public RectTransform consumablesInventoryPanel;
    public RectTransform consumablesScrollViewContent;
    public RectTransform resourcesInventoryPanel;
    public RectTransform resourcesScrollViewContent;
    public RectTransform craftablesInventoryPanel;
    public RectTransform craftablesScrollViewContent;
    public RectTransform questsInventoryPanel;
    public RectTransform questScrollViewContent;

    //Reference to itemContainer prefab for item slots
    InventoryUIItem itemContainer;

    //See if inventory UI is active
    bool isInventoryActive;

    //Know which item is currently selected to display info
    Item currentSelectedItem { get; set; }

    void Start()
    {
        //Loads item container prefab for inventory slots
        itemContainer = Resources.Load<InventoryUIItem>("InventoryUI/ItemContainer");

        //Helps UI know which item added to inventory. Event is known    
        UIEventHandler.OnItemAddedToInventory += itemAdded;

        //Add quest to event system like above
        UIEventHandler.OnQuestAddedToInventory += questAdded;
    }

    //So UI knows is added
    public void itemAdded(Item item)
    {
        //Updates Inventory UI to add more items
        //Because of event system, adds these

        if (item.quantity < 0)
        {
            return;
        }

        //This means an item was removed and no more are in inv
        if (item.quantity == 0)
        {
            if (item.itemType == Item.ItemType.Resource)
            {
                foreach (Transform child in resourcesScrollViewContent)
                {
                    if (child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
            else if (item.itemType == Item.ItemType.Consumable)
            {
                foreach (Transform child in consumablesScrollViewContent)
                {
                    if (child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
            else if (item.itemType == Item.ItemType.Weapon)
            {
                foreach (Transform child in weaponsScrollViewContent)
                {
                    if (child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
                    {
                        Destroy(child.gameObject);
                    }
                }
            }

            return;
        }

        //Creates a new item container which holds item information as UI element 
        InventoryUIItem emptyItem = Instantiate(itemContainer);

        //This deals with item stacking, if resources already has UI element with given item, delete current item UI and create a new one with updated quantity
        if (item.itemType == Item.ItemType.Resource)
        {
            foreach (Transform child in resourcesScrollViewContent)
            {
                if (child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (item.itemType == Item.ItemType.Consumable)
        {
            foreach (Transform child in consumablesScrollViewContent)
            {
                if (child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else if (item.itemType == Item.ItemType.Weapon)
        {
            foreach (Transform child in weaponsScrollViewContent)
            {
                if (child.transform.Find("ItemName").GetComponent<Text>().text == item.name)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        //Set item information for UI
        emptyItem.setItem(item);

        //Assign item container to correct tab
        if (item.itemType == Item.ItemType.Resource)
        {
            emptyItem.transform.SetParent(resourcesScrollViewContent, false);
        }
        if (item.itemType == Item.ItemType.Consumable)
        {
            emptyItem.transform.SetParent(consumablesScrollViewContent, false);
        }
        if (item.itemType == Item.ItemType.Weapon)
        {
            emptyItem.transform.SetParent(weaponsScrollViewContent, false);
        }
        if (item.itemType == Item.ItemType.Craftable)
        {
            emptyItem.transform.SetParent(craftablesScrollViewContent, false);
        }
    }

    //Seperate system for quests
    public void questAdded(Quest quest)
    {
        //Creates a new item container which holds item information as UI element 
        InventoryUIItem emptyItem = Instantiate(itemContainer);

        //Set quest information for UI
        emptyItem.setQuest(quest);

        //Assign quest container to correct tab
        emptyItem.transform.SetParent(questScrollViewContent, false);
    }

    void Update()
    {
        //To pull up and get off of inventory, look for inventory key press
        if (Input.GetButtonDown("Inventory"))
        {
            //Does opposite of whatever is up, so if inventory is pulled up, pressing again closes it
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    /*
     * Out dated code that worked with inventoryslots script. Leaving for reference for future if curious of another method of implementation
    void updateUI()
    {
        Debug.Log("Updating UI");

        //Go through all slots to add item
        for(int i = 0; i < itemSlots.Length; i++)
        {
            //Means inventory isnt full
            if(i < inventory.items.Count)
            {
                GameObject itemSlot = Instantiate(itemSlotPrefab);

                //Add item to specific inventory slot
                itemSlots[i].addItem(inventory.items[i]);
            }
            else
            {
                //Out of inventory items to add
                itemSlots[i].clearSlot();
            }
        }

    }
    */
}
