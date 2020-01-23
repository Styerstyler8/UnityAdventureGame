using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTylerKnightTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Inventory.instance.addSword();
            FindObjectOfType<DialogueManager>().TylerKnightButtonOnOrOff(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManager>().TylerKnightButtonOnOrOff(0);
        }
    }

}
