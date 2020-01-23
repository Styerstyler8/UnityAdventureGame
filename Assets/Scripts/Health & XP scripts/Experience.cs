using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {

	public GameObject experienceBar;
	public GameObject experienceText;
    public GameObject player;
	float barLength;

    int playerLevel = 1;
    int currentXP = 0;
    int xpToLevelUp = 100;

	// Use this for initialization
	void Start () {
		experienceText.GetComponent<Text> ().enabled = false;
        playerLevel = 1;
        currentXP = 0;
        xpToLevelUp = 100;
	}

	void Update () {
		barLength = (1.0f * currentXP / xpToLevelUp) * 2.75f;
		experienceBar.GetComponent<RectTransform>().localScale = new Vector3(barLength,0.175f,1.0f);
		experienceText.GetComponent<Text> ().text = currentXP.ToString() + " / " + xpToLevelUp.ToString();
	}

    private void LevelUp()
    {
        playerLevel++;
        FindObjectOfType<DialogueAudio>().LevelUpNoise();
        // TODO Upgrade player Stats
		if (player)
        	AddSkillPoints(5);
        currentXP = currentXP - xpToLevelUp;
        xpToLevelUp += 100;
        print("Player has leveled up and is now level: ");
        print(playerLevel);
        if (currentXP >= xpToLevelUp)
            LevelUp();
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        if (currentXP >= xpToLevelUp)
            LevelUp();
    }

    public void AddSkillPoints(int numberOfSkillPoints)
    {
        player.GetComponent<Player>().playerStats.SetSkillPoints(5 + player.GetComponent<Player>().playerStats.GetSkillPoints());
    }

	public int GetLevel() {
		return playerLevel;
	}

	public int GetCurrentXP() {
		return currentXP;
	}

    public int GetXPToLevelUp()
    {
        return xpToLevelUp;
    }

	void OnMouseEnter() {
		experienceText.GetComponent<Text> ().enabled = true;
	}

	void OnMouseExit() {
		experienceText.GetComponent<Text> ().enabled = false;
	}
}
