using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableRock : MonoBehaviour {

    public int rockPerHit = 5;
    public int rockHealth = 10;

    public void MineRock(int miningPower)
    {
        rockHealth -= miningPower;
    }

    public int GetRockHealth()
    {
        return rockHealth;
    }

}
