using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : MonoBehaviour, IEnemy {

	public float currentHealth;
    public float MaxHealth;
    public CharacterStat goblinStats;
    public DropTable dropTable;
    public ItemPickup goblinDrop;
    public int goblinID;
    static int IDCounter = 0;
    public Image healthBar;
    public GameObject player;
    Animator animator;
    public GoblinSword weapon;
    public Rigidbody rigidBody;

    void Start() {
        goblinID = IDCounter++;
        //attack, defense, consitution, vitality
        goblinStats = new CharacterStat(10,10,50,50);
        currentHealth = MaxHealth = (int)goblinStats.GetStat(StatType.Constitution).getTotalValue();
        dropTable = new DropTable();
        dropTable.listOfDrop = new List<LootDrop>() {
            new LootDrop("Sword",100),
            new LootDrop("Sword_2H",0),
            new LootDrop("Axe",0)
        };
        animator = GetComponent<Animator>();
        weapon = GameObject.FindGameObjectWithTag("EnemyWeapon").GetComponent<GoblinSword>();
        rigidBody = GetComponent<Rigidbody>();
        Debug.Log("start is null");
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void PerformAttack() {
        if(animator.GetBool("Attacking")) {
            float attackDamage = weapon.GetStats()[(int)StatType.Attack].getTotalValue() + goblinStats.GetStat(StatType.Attack).getTotalValue();
            weapon.PerformAttack((int)attackDamage);
        }
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth/MaxHealth;
        if (currentHealth <= 0) {
            animator.SetBool("isDead", true);
            rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            StartCoroutine(playAndWaitForAnim());

        }
 //       else
 //       {
 //           FindObjectOfType<DialogueAudio>().GoblinDamageNoise();
 //       }
    }
    
    private void Die() {
        FindObjectOfType<DialogueAudio>().GoblinDies();
        DropLoot();

        player.GetComponent<Experience>().AddXP(50);
        Destroy(gameObject);
    }

    private void DropLoot() {
        Item potentialDrop = dropTable.getDrop();
        if(potentialDrop != null) {
            GameObject weapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/ScriptedWeapons/" + potentialDrop.name), transform.position, Quaternion.identity);
            //ItemPickup temp = weapon.GetComponent<ItemPickup>();
            //temp.item = potentialDrop;
        }
    }

    IEnumerator playAndWaitForAnim() {
        yield return new WaitForSeconds(2);
        Die();
    }
}
