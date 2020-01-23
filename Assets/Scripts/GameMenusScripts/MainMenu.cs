using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Transform Player;

	public void PlayGame ()
	{
        FindObjectOfType<MainMenuSounds>().ButtonClick();
        SceneManager.LoadScene ("StartArea");
	}

    public void LoadGame ()
    {     
        SceneManager.LoadScene("StartArea");
    }


    public void QuitGame ()
	{
		Debug.Log ("Quit has been pressed");
		Application.Quit ();
	}
}
