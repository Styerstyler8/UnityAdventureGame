
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStat {

    public float bonus;
    public StatType stat;
    public string discription;

    public BonusStat(float bonus, StatType stat, string discription) {
        this.bonus = bonus;
        this.stat = stat;
        this.discription = discription;
    }
}
