using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is just a test
public class Wood : MonoBehaviour, IConsumables {

    //2 different possibilities for consuming item. One that just does something, and one that effects character's stats
    //This allows each item to have a certain consume function
    public void consume()
    {
        Debug.Log("You picked up wood!");
    }

    public void consume(CharacterStat stats)
    {
        Debug.Log("Some wood for you");
    }
}
