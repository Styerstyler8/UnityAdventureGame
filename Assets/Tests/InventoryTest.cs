/*
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class InventoryTest {
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode

    //Tests if inventory gets the same item that is picked up 
	[UnityTest]
	public IEnumerator InventoryUpdatesAddingItem() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase();

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        //inv.addTest("TESTITEM", itemDatabase); //Calls inventory method to add item

        var items = inv.getItems(); //Gets the list of items in inventory class

        var itemInSlot1 = items[0]; //Gets the first slot of inventory

        yield return null;  //Waits a second

        Assert.AreEqual(itemInSlot1.name, "TESTITEM"); //Asserts item picked up and item in 1st inv slot are same
    }
    
    //Checks to see if 1st slot in inv is empty after adding item, then removing it
    [UnityTest]
    public IEnumerator InventoryUpdatesRemovingItem()
    {
        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase();

        var inv = new GameObject().AddComponent<Inventory>();

        //inv.addTest("TESTITEM", itemDatabase); //Calls inventory method to add item

        Item item = itemDatabase.getItem("TESTITEM");
        inv.Remove(item);

        var items = inv.getItems(); //Same as above

        bool exceptionCaught = false; //Exception should be thrown for going out of bounds of list, bool to track

        try
        {
            var itemInSlot1 = items[0]; //Try to get 1st item in empty list
        }
        catch(System.Exception e)
        {
            exceptionCaught = true; //Means successfuly do not have item in inv
        }

        yield return null;

        Assert.IsTrue(exceptionCaught); //Asserts error was thrown
    }

    //Checks to see if number of items in inventory is 1 after adding an item
    [UnityTest]
    public IEnumerator InventoryCount()
    {
        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase();

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        inv.addTest("TESTITEM", itemDatabase); //Calls inventory method to add item

        int itemCount = inv.items.Count; //Item count for inventory should be 1

        yield return null;

        Assert.AreEqual(itemCount, 1); //Asserts item count of inv == 1
    }

    //Checks to see if item is added twice to list after adding same item, and item quantity is updated to 2
    [UnityTest]
    public IEnumerator InventoryStacking()
    {
        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase();

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        inv.addTest("TESTITEM", itemDatabase); //Calls inventory method to add item
        inv.addTest("TESTITEM", itemDatabase);

        bool quantityAndCountUpdated = false; //Will be true if item quantity is 2 after adding 2 of same item and list of items only has 1 item

        int itemCount = inv.items.Count; //Item count for inventory should be 1

        if(itemCount == 1 && inv.items[0].quantity == 2)
        {
            quantityAndCountUpdated = true;
        }

        yield return null;

        Assert.IsTrue(quantityAndCountUpdated); //Asserts item count of inv == 1, as only one type of item was added
    }

    //Checks to see if item stack limit is 99, and item cannot be added again after limit reached
    [UnityTest]
    public IEnumerator itemStackLimitReached()
    {
        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase();

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        int stackSize = 0; //Value to hold item quantity

        for(int i = 0; i < 102; i++)
        {
            inv.addTest("TESTITEM", itemDatabase); //Calls inventory method to add item
        }

        stackSize = inv.items[0].quantity;

        yield return null;

        Assert.AreEqual(stackSize, 99); //Asserts item count of item added is 99, not over
    }

    //Deletes everything created
    [TearDown]
    public void AfterEveryTest()
    {
        foreach(var GameObject in GameObject.FindObjectsOfType<Inventory>())
        {
            Object.Destroy(GameObject);
        }

        foreach (var GameObject in GameObject.FindObjectsOfType<ItemDatabase>())
        {
            Object.Destroy(GameObject);
        }
    }
}
*/