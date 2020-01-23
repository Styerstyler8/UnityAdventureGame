using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {

    void PerfromAttack(float damage);

    List<BaseStat> GetStats();

    void SetStats(List<BaseStat> newStats);

    StatType AttackType();
}
