using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSword : MonoBehaviour {
    public List<BaseStat> swordStats;
    public int maxHit = 0;
    public int attackDamage;
    bool isAttacking;

    void Awake() {
        maxHit = 0;
        isAttacking = false;
        swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(StatType.Attack, attackDamage, "Attack", "attackonly"));
        swordStats.Add(new BaseStat(StatType.Defense, 0, "Defense", "Defense"));
        swordStats.Add(new BaseStat(StatType.Constitution, 0, "Constitution", "Constitution"));
        swordStats.Add(new BaseStat(StatType.Vitality, 0, "Vitality", "Vitality"));
    }

    public void PerformAttack(int damage) {
        maxHit = damage;
        isAttacking = true;
    }
    public void SetStats(List<BaseStat> newStats) {
        swordStats = newStats;
    }
    public List<BaseStat> GetStats() {
        return swordStats;
    }

    void OnTriggerEnter(Collider hitObject) {
  
        if (hitObject.tag == "Player" && isAttacking) {
            isAttacking = false;
            hitObject.GetComponent<Health>().TakeDamage(maxHit);
            Debug.Log("Goblin did" + maxHit + " damage");
        }
    }
}
