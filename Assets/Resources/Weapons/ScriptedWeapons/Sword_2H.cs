using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_2H : MonoBehaviour, IWeapon {

    List<BaseStat> swordStats;
    float maxHit = 0.0f;
    private Animator playerAnimator;
    bool isAttacking;

    void Start() {
        maxHit = 0.0f;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        isAttacking = false;
    }
    public void PerfromAttack(float damage) {
        maxHit = damage;
        playerAnimator.SetTrigger("Attack");
        isAttacking = true;
    }
    public List<BaseStat> GetStats() {
        return swordStats;
    }

    public void SetStats(List<BaseStat> newStats) {
        swordStats = newStats;
    }
    public StatType AttackType() {
        return StatType.Attack;
    }
    void OnTriggerEnter(Collider hitObject) {
        if (hitObject.tag == "Enemy" && isAttacking) {
            isAttacking = false;
            hitObject.GetComponent<IEnemy>().TakeDamage(maxHit);
            Debug.Log("did" + maxHit + " damage");
        }
    }
}
