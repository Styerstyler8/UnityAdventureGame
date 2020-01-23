using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject equippedWeapon;
    public CharacterStat characterStats;
    public IWeapon weapon;
    private Animator animator;

    // Use this for initialization
    void Start() {
        characterStats = GetComponent<Player>().playerStats;
        animator = GetComponent<Animator>();
    }


    public void EquipWeapon(Item weapon) {
        //unequip weapon if weapon is equipped
        if (equippedWeapon != null) {
            //remove weapon stats from play
            characterStats.RemoveStatBonus(this.weapon.GetStats());
            Destroy(equippedWeapon);
            equippedWeapon = null;
            //set appropriate animation
            animator.SetBool(weapon.animationKey, false);
        }
        //creates a new instance of a weapon and spawn it in the players hand
        else {
            //load game object from resources and attach to hand
            equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/ScriptedWeapons/" + weapon.name), playerHand.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
            equippedWeapon.transform.SetParent(playerHand.transform);
            //rotate and position weapon into correct position
            equippedWeapon.transform.localRotation = Quaternion.Euler(new Vector3(weapon.rotation_x, weapon.rotation_y, weapon.rotation_z));
            equippedWeapon.transform.localPosition = new Vector3(weapon.position_x, weapon.position_y, weapon.position_z);
            //set member variable to keep track of current weapon
            this.weapon = equippedWeapon.GetComponent<IWeapon>();
            //add weapon stats to player
            this.weapon.SetStats(weapon.stats);
            characterStats.AddStatBonus(weapon.stats);
            //set appropriate weapon animation
            animator.SetBool(weapon.animationKey, true);

        }

    }
    //Update is called once per frame
    void Update() {
        if (weapon != null) {
            if (Input.GetKeyDown(KeyCode.O)) {
                PerformAttack();
            }
        }
    }
    private void PerformAttack() {
        float damage = CalculateMaxHit();
        weapon.PerfromAttack(damage);
    }
    //a weapons damage is based off stat type plus bonus value 
    //i.e. sword damage = attack + bonous attack, bow damge = ranged + bonus ranged
    private float CalculateMaxHit() {
        float damage = characterStats.stats[(int)weapon.AttackType()].getTotalValue();
        damage = damage +  (int)(damage * Random.Range(.01f, .1f));
        //CRITICAL HIT
        if(Random.value <= .1f) {
            damage += (int)(characterStats.stats[(int)StatType.Vitality].getTotalValue() * Random.Range(.45f, .8f));
        }
        return damage;
    }
}

