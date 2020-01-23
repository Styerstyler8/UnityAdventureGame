using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {
    public Transform Player;
    
    /*void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadGameSettings();
    }*/
    public void SaveGameSettings(bool Quit)
    {
        PlayerPrefs.SetFloat("x", Player.position.x); //saves x position to registry labeled 'x'
        PlayerPrefs.SetFloat("y", Player.position.y); //saves y position to registry labeled 'y'
        PlayerPrefs.SetFloat("z", Player.position.z); //saves z position to registry labeled 'z'
        PlayerPrefs.SetFloat("Cam_y", Player.eulerAngles.y); //uses vector3 scale to store rotation
        if (Quit)//if save and exit
        {
            Time.timeScale = 1;//let time flow normally
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive); //load main menu
        }
    }


    
	
}
