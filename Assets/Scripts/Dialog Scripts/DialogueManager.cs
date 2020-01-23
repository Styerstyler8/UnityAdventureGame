using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //so we can edit the panel thing and have it display the appropriate text. 

public class DialogueManager : MonoBehaviour {
    public Text nameText; //the name of our NPC
    public Text dialogueText; //the dialogue that will be spoken
    public GameObject startConversatoin; //the button that starts a conversatoin
    public GameObject knightConversation; //the button that starts a conversation with the Knight
    public GameObject dialoguePanel; //the panel for the dialogue
//    public Transform canvas; //the canvas
    public GameObject knightHead; //so we know where the head of the knight is
 // public Transform player; //this is the player
 //   public Camera mcamera; //the camera
    private Vector3 adder; //how much we have to add to the head so that the dialogue goes in the right place
    //in order to control the comming in and going out animation we created for the conversation dialogue box panel, we need a reference to
    //its animator compoenent
   // public Animator animator; //this is how we control the animations for the panel
    private Queue<string> sentences; //variable taht will keep track of all our sentences in our dialogue

    //Added by Tyler:
    public GameObject TylerKnightConversation; //the button that starts a conversation with the Tyler's Knight
    public GameObject TylerknightHead; //so we know where the head of the knight is
    private Queue<string> questCompletedSentences;

    // Use this for initialization
    void Start ()
    {
        sentences = new Queue<string>(); //initialize the Queue
        startConversatoin.SetActive(false); //make the start button invisible
        knightConversation.SetActive(false); //make the start button invisible
        dialoguePanel.SetActive(false); //make the dialogue panel invisible
        adder[1] = 1; //set the Y component of teh adder verctor to 10 so that the dialogue box will go up by 10

        //Tyler addition:
        TylerKnightConversation.SetActive(false);
        questCompletedSentences = new Queue<string>();
    }

    void Update()
    {

    }

    //function used to turn the start conversation for the knight on or off
    public void KnightButtonOnOrOff(int number)
    {
        if (number == 1) //if the number is one
        {
            knightConversation.SetActive(true); //turn the button on
            knightConversation.transform.position = knightHead.transform.position + adder; //make the start button appear above the knight
        }
        else if (number == 0) //else if the number is zero
        {
            knightConversation.SetActive(false); //turn the button off
        }
    }

    public void StartDialogue(Dialogue dialogue, GameObject NPC, bool questComplete, GameObject NPCHead)
    {
        //   animator.SetBool("IsOpen", true); //set the "IsOPen" parameter to true because we are starting a new dialogue
        string path = "";
        string npcName = NPC.name;
        path = path + "/" + npcName + "/PotatoCookie";
        GameObject top = NPCHead;
      //  GameObject top = GameObject.Find(path);
        
        dialoguePanel.SetActive(true);//now that we are strating a conversation we want to make teh dialogue panel appear
        dialoguePanel.transform.position = top.transform.position + adder; //make dialogue panel appear above the knight
        Debug.Log(top);
        Debug.Log(path);
        //this long line below is used to rotate the dialogue panel
   //     dialoguePanel.transform.eulerAngles = new Vector3(dialoguePanel.transform.eulerAngles.x, dialoguePanel.transform.eulerAngles.y + -5,
   //                                                        dialoguePanel.transform.eulerAngles.z);
        nameText.text = dialogue.name; //set teh name of our character to display on the conversation panel.
        sentences.Clear(); //we first want to clear any sentences taht were there from a prevoius conversation
        if (!questComplete)
        {
            foreach (string sentence in dialogue.sentences) //we then go through all of the strings in our dialogue.sentences array
            {
                sentences.Enqueue(sentence); //we wnat to queueu up a sentence. put in the sentence we are currently looking at
            }
        }
        else
        {
            foreach (string sentence in dialogue.questCompletedSentences) //we then go through all of the strings in our dialogue.sentences array
            {
                sentences.Enqueue(sentence); //we wnat to queueu up a sentence. put in the sentence we are currently looking at
            }
        }

        //we want to display the next sentence after they are put in teh Queue
        DisplayNextSentence();
    }

    //this methd is public so taht we can call it from our continue button
    public void DisplayNextSentence()
    {
        //we want to check if there even are more sentences in teh Queue. If this is true we have reached the end of our Queue and we can end our dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return; //we are just returning out of the rest of the function
        }
        //if we still have sentences left to say then we want to get the next sentence in teh queue. 
        string sentence = sentences.Dequeue();
        //there is a possiblitity that teh user will start a new sentence before the prevoius sentence has finished animating
        //in thata case we want to make sure it stops animating before we start animating the new one. To do this we use the 
        //StopAllCoroutines(); function. If TypeSentence is already running, we can stop doing so and run a new one. 
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // Call the Coruitine called TypeSentence
    }

    //this is so taht our letters in our dialogue box do not just suddenly appear. We want them to animate one by one
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = ""; //set it equal to an empty string
        foreach (char letter in sentence.ToCharArray()) //loop through all the individual characters in our sentence
        {
            //dsiplay teh dialogue text in the conversation panel. Add our letter onto the dialogue text one by one
            dialogueText.text = dialogueText.text + letter;
            yield return null; //after each letter, wait a small amount of time. Wait a single frame. 
        }
    } 

    //function that ends the dialogue
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
   //     animator.SetBool("IsOpen", false); //set the "IsOPen" parameter to false because we are closing a dialogue
    }

    public void TurnOnButton()
    {
        knightConversation.SetActive(true);
    }
    //Tyler aditions:
    //function used to turn the start conversation for the knight on or off
    public void TylerKnightButtonOnOrOff(int number)
    {
        if (number == 1) //if the number is one
        {
            TylerKnightConversation.SetActive(true); //turn the button on
            TylerKnightConversation.transform.position = TylerknightHead.transform.position + adder;
        }
        else if (number == 0) //else if the number is zero
        {
            TylerKnightConversation.SetActive(false); //turn the button off
        }
    }

}
