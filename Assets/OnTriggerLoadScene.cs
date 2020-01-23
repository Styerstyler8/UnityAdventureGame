using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerLoadScene : MonoBehaviour {

    public GameObject textUI; //Text that appears for what button to press to change scenes
    public string sceneToLoad; //The name of the scene to load

    private void Start()
    {
        textUI.SetActive(false);
    }

    //When player enters trigger area, do this
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //If player in trigger, if they press button to load, load scene
            textUI.SetActive(true);
            if(textUI.activeInHierarchy && Input.GetButtonDown("LoadScene"))
            {
                Application.LoadLevel(sceneToLoad);
            }
        }
    }

    void onTriggerExit()
    {
        textUI.SetActive(false);
    }
}
