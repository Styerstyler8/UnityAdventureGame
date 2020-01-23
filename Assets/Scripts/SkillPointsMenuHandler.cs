using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointsMenuHandler : MonoBehaviour {

    GameObject skillPointsUI;
    bool isOpen = false;

    // Use this for initialization
    void Start () {
        skillPointsUI = GameObject.Find("Skill Menu");
        skillPointsUI.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("k"))
        {
            skillPointsUI.SetActive(!isOpen);
            isOpen = !isOpen;
        }
	}
}
