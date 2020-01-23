//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DialogueSystem : MonoBehaviour {
//    //potato1
//    public static DialogueSystem Instance { get; set; }
//    public List<string> dialogueLines = new List<string>(); //list of things we can populate with the lines taht we passed over from that new dialogue. 
//                                                            //our new dialogue with the string that gets passed into the "AddNewDialogue" function

//    public string npcName;
//    public GameObject dialoguePanel; //use this to reference the dialogue panel. Which we can then use to grab the children of the dialogue panel. And this will give us
//                                     //continue, text, and name
//    Button continueButton; //the dialogue's continue button
//    Text dialogueText; //the text that is in the dialogue
//    Text nameText; //the name of the character we are talking to
//    int dialogueIndex; //the index to which message in the dialogue we are in

//    // Use this for initialization
//    void Awake () {
//        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>(); //now we have the Dialogue's continue button
//        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>(); //now we have the dialogue's text
//        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>(); //if you look in the Hierachy, "Name" is a panel and in there, there is a "Text"
//                                                                                               //GetChild(0) gets the first child (the zero'th child) of Name. 
//        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
//        dialoguePanel.SetActive(false); //set the active state of dialogue panel game object to false. On awake there should be no reasoon for the dialogue to show
//                                        //because teher is not going to be dialogue unless you want to start a new dialogue. So make sure that at start teh dialogue panel is false
        

//        //if theses conditions are met then taht means taht an instance exists taht isn't this instance
//        //does it exist and if it does exist is it equal to this object. This dialogue system we have created here: potato1
//		if (Instance != null && Instance != this)
//        {
//            Destroy(gameObject); //so we destroy it
//        }
//        //else if those conditions are not met then that means that an instance does not exist. And we 
//        else
//        {
//            Instance = this; //this is a refernece to this instance. The one we have created by dragging and dropping hte component on a game object in our heirarchy
//                             //so now it exists and we can reference it with "Instance"
//        }
//	}
	
//    public void AddNewDialogue(string[] lines, string npcName)
//    {
//        dialogueIndex = 0; //the dialogue index should be zero whenever we add new dialogue. 
//        dialogueLines = new List<string>(lines.Length); //makes a new dialoguelines the size of the string array the function takes in.
//        dialogueLines.AddRange(lines); //we add them to the dialogueLines list.
//        Debug.Log(dialogueLines.Count);
//        this.npcName = npcName; //the npc name given in this funciton is the npc name of this instance
//        CreateDialogue(); //call the function that creates a dialogue
//    }

//    //going to handle enabling the dialogue panel as well as assigning the text values to the elements inside of that panel
//    public void CreateDialogue()
//    {
//        dialogueText.text = dialogueLines[dialogueIndex]; //we want the first index in dialogue lines. we want to show the first bit of text.
//        nameText.text = npcName; //the name box thing is the NPCs name
//        dialoguePanel.SetActive(true); //re enable the panel thing.
//    }

//    //increase teh dialogue index and show the new message
//    public void ContinueDialogue()
//    {
//        if (dialogueIndex < dialogueLines.Count - 1) //if the index is less than how many messages we have
//        { 
//            dialogueIndex = dialogueIndex + 1; //move the index by one. 
//            dialogueText.text = dialogueLines[dialogueIndex]; //the new stuff shown on the dialogue screen should be the next element in the dialoguelines array
//        }
//        else //else if we've seen all the text there is to see and now it is time to close the panel
//        {
//            dialoguePanel.SetActive(false);
//        }
//    }
//}
