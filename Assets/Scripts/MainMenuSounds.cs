using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSounds : MonoBehaviour {

    public AudioClip click;
    public AudioSource clickSource;

    private void Start()
    {
        clickSource.clip = click;
    }

    public void ButtonClick()
    {
        clickSource.Play();
    }
}
