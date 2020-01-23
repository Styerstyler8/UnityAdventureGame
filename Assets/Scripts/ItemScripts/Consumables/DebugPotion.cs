using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an example of creating a script for a consumable
public class DebugPotion : MonoBehaviour, IConsumables {

    //2 different possibilities for consuming item. One that just does something, and one that effects character's stats
    //This allows each item to have a certain consume function
    public void consume()
    {
        Debug.Log("This is a test to make sure consume works.");
    }

    public void consume(CharacterStat stats)
    {
        Debug.Log("This is a test to make sure consume works with a stat change");
    }
}
