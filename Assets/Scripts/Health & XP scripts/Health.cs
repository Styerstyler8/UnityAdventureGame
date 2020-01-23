using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject healthBar;
	public GameObject healthText;
    public Animator playerAnimator;
    float barLength;

    int totalHealth;
    int currentHealth;


	// Use this for initialization
	void Start () {
		healthText.GetComponent<Text> ().enabled = false;
        totalHealth = 100;
        currentHealth = totalHealth;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        barLength = (1.0f * currentHealth / totalHealth) * 2.75f;
        healthBar.GetComponent<RectTransform>().localScale = new Vector3(barLength,0.23f,1.0f);
		healthText.GetComponent<Text> ().text = currentHealth.ToString() + " / " + totalHealth.ToString();
	}

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth - damageAmount < 0)
        {
            FindObjectOfType<DialogueAudio>().PlayerDies();
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damageAmount;
            FindObjectOfType<DialogueAudio>().PlayerDamageNoise();
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth + healAmount > totalHealth)
        {
            currentHealth = totalHealth;
        }
        else
            currentHealth += healAmount;
    }

	void OnMouseEnter() {
		healthText.GetComponent<Text> ().enabled = true;
	}

	void OnMouseExit() {
		healthText.GetComponent<Text> ().enabled = false;
	}

    public int GetHealth() { return currentHealth; }

    public void SetHealth(int newHealth) { currentHealth = newHealth; }
    
}
