using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is essentially supposed to be the NPC script from the other video. I think normally you would attatch this to whatever NPC character you wanted. 
//to make a new NPC thing with a new dialogue you would have to create an empty object. Reset its transform. Name the empty object the name of the NPC.
//attatch the dialogue trigger to this new game object. Change the name in the dialogue parameter to the name of the NPC. And then give her some sentences to say
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; //using the data type that we just created. The dialogue class. 
    public GameObject NPCHead; //the head of the NPC
    //way to feed stuff to our dialogue manager
    public void TriggerDialogue()
    {
        //If quest for this NPC exists, add to inventory when dialogue starts and when spoken to again, check if done
        if (quest != null)
        {
            if (!hasRecievedQuest)
            {
                Inventory.instance.addQuest(quest);
                hasRecievedQuest = true;
            }
            else
            {
                quest.checkObjectives();

                if (quest.isComplete)
                {
                    hasCompletedQuest = true;
                }
            }
        }

        //we want to find an object of type DialogueManager. And now that we found this object we want to call the function StartDialogue and give it a function
        //argument to tell it what conversation to start (we pass in our dialogue variable. 
        FindObjectOfType<DialogueManager>().KnightButtonOnOrOff(0); //turn the button off because they want to start conversatoin

        if (hasCompletedQuest)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject, true, NPCHead);  //locate our dialogue manager. 
        }
        else if (quest != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject, quest.isComplete, NPCHead);  //locate our dialogue manager. 
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject, false, NPCHead);  //locate our dialogue manager. 
        }

    }

    //Tyler addition:
    public Quest quest; //Quest to give player, does not need to be set if no quest for this NPC

    private bool hasRecievedQuest; //Bool to keep track if player has gotten quest yet

    private bool hasCompletedQuest; //Bool to keep track if player completed quest yet

    //Initialize values
    private void Start()
    {
        hasRecievedQuest = false;
        hasCompletedQuest = false;
        quest = GetComponent<Quest>();
    }

    public void TylerTriggerDialogue()
    {

        //If quest for this NPC exists, add to inventory when dialogue starts and when spoken to again, check if done
        if (quest != null)
        {
            if (!hasRecievedQuest)
            {
                Inventory.instance.addQuest(quest);
                hasRecievedQuest = true;
            }
            else
            {
                quest.checkObjectives();

                if (quest.isComplete)
                {
                    hasCompletedQuest = true;
                }
            }
        }

        //we want to find an object of type DialogueManager. And now that we found this object we want to call the function StartDialogue and give it a function
        //argument to tell it what conversation to start (we pass in our dialogue variable. 
        FindObjectOfType<DialogueManager>().TylerKnightButtonOnOrOff(0); //turn the button off because they want to start conversatoin

        if (hasCompletedQuest)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject, true, NPCHead);  //locate our dialogue manager. 
        }
        else if (quest != null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject, quest.isComplete, NPCHead);  //locate our dialogue manager. 
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this.gameObject, false, NPCHead);  //locate our dialogue manager. 
        }

    }

}
