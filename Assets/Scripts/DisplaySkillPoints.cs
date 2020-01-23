using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySkillPoints : MonoBehaviour {

    public GameObject player;
    public CharacterStat characterStats;

    void Start()
    {
        characterStats = player.GetComponent<Player>().playerStats;
    }

    // Update is called once per frame
    void Update () {
    //GetComponent<Player>().playerStats
        this.GetComponent<Text>().text = "Stat Points: " + characterStats.GetSkillPoints().ToString();
	}
}
