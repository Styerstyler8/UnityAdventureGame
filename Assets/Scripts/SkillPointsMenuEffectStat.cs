using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointsMenuEffectStat : MonoBehaviour {

	public GameObject player;
	public Text skillText;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void IncreasePlayerStat(int statNumber) {
		if (player.GetComponent<Player>().playerStats.GetSkillPoints () > 0) {
			float originalValue = player.GetComponent<Player>().playerStats.GetStats () [statNumber].getBaseValue ();
			player.GetComponent<Player>().playerStats.GetStats () [statNumber].setBaseValue ((int)originalValue + 1);

			string skillName = player.GetComponent<Player>().playerStats.GetStats () [statNumber].getName ();
			skillText.text = skillName + ": " + player.GetComponent<Player>().playerStats.GetStat (statNumber).ToString ();


			player.GetComponent<Player>().playerStats.SetSkillPoints( player.GetComponent<Player>().playerStats.GetSkillPoints()-1);
		}
	}

	public void DecreasePlayerStat(int statNumber) {
		float originalValue = (int)player.GetComponent<Player>().playerStats.GetStats () [statNumber].getBaseValue ();
		if ((int)originalValue > 1) {
			player.GetComponent<Player>().playerStats.GetStats () [statNumber].setBaseValue ((int)originalValue - 1);
			string skillName = player.GetComponent<Player>().playerStats.GetStats () [statNumber].getName ();
			skillText.text = skillName + ": " + player.GetComponent<Player>().playerStats.GetStat (statNumber).ToString ();

			player.GetComponent<Player>().playerStats.SetSkillPoints( player.GetComponent<Player>().playerStats.GetSkillPoints()+1);

		}
	}
}
