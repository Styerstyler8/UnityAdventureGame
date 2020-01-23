using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseGame : MonoBehaviour {
    public Transform Canvas;
    public Transform player;

    void Awake()
    {
        LoadGameSettings();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }	
	}
    public void Pause ()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            //player.GetComponent<ThirdPersonUserControl>().enabled = false;
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            //player.GetComponent<ThirdPersonUserControl>().enabled = true;
        }
    }

    public void LoadGameSettings()
    {
        player.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z")); //Upon restart load game
        player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("Cam_y"));
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
    }
}
