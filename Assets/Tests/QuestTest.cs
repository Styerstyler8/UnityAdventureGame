using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

public class QuestTest
{
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode

    //Tests if method for adding a quest to the inventory works
    [UnityTest]
    public IEnumerator questAddedToInventory()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        var exampleQuest = new GameObject().AddComponent<Quest>(); //Create an example quest to test and assign some of its basic needs
        exampleQuest.questName = "Test";
        exampleQuest.experienceAward = 20;
        exampleQuest.isComplete = false;
        exampleQuest.itemReward = "TESTITEM";

        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase(); //Build item database to allow access to items

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        inv.addQuestTest(exampleQuest); //Calls inventory method to add quest

        var quests = inv.getQuests(); //Gets the list of quests in inventory class

        var questInSlot1 = quests[0]; //Gets the first slot of inventory

        yield return null;  //Waits a second

        Assert.AreEqual(questInSlot1.questName, "Test"); //Asserts quest's name and quest in 1st inv slot have same name
    }

    //Tests if quest is completed after completing its objective
    [UnityTest]
    public IEnumerator questRemovedAfterCompletion()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        var exampleQuest = new GameObject().AddComponent<Quest>(); //Create an example quest to test and assign some of its basic needs
        exampleQuest.questName = "Test";
        exampleQuest.experienceAward = 20;
        exampleQuest.isComplete = false;
        exampleQuest.itemReward = "Wood";

        CollectObjective exampleObj = new CollectObjective(exampleQuest, "TESTITEM", "Collect a test item", false, 0, 1); //Example objective made for a quest, that asks for a tesitem to be picked up

        exampleQuest.objectives.Add(exampleObj); //Add objective to quest

        var itemDatabase = new GameObject().AddComponent<ItemDatabase>(); //Creates item database and builds it to allow access to items
        itemDatabase.buildDatabase(); //Build item database to allow access to items

        var inv = new GameObject().AddComponent<Inventory>(); //Creates inventory object

        inv.addQuestTest(exampleQuest); //Calls inventory method to add quest

        inv.addTest("TESTITEM", itemDatabase); //Adds one testitem to inventory, to complete quest

        exampleObj.itemPickedUp(itemDatabase.getItem("TESTITEM")); //Checks if item picked up is the one needed for quest

        exampleQuest.checkObjectivesTest(); //Check if all the objectives for the quest are complete

        yield return null;  //Waits a second

        Assert.IsTrue(exampleQuest.isComplete); //Should return true indicating all objectives of the quest are completed
    }

    //Deletes everything created
    [TearDown]
    public void AfterEveryTest()
    {
        foreach (var GameObject in GameObject.FindObjectsOfType<Inventory>())
        {
            Object.Destroy(GameObject);
        }

        foreach (var GameObject in GameObject.FindObjectsOfType<ItemDatabase>())
        {
            Object.Destroy(GameObject);
        }

        foreach (var GameObject in GameObject.FindObjectsOfType<Quest>())
        {
            Object.Destroy(GameObject);
        }
    }
}