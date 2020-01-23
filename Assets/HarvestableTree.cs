using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableTree : MonoBehaviour {

    public int woodPerHit = 5;
    public int treeHealth = 10;

    public void ChopWood(int choppingPower)
    {
        treeHealth -= choppingPower;
    }

    public int GetTreeHealth()
    {
        return treeHealth;
    }
}
