using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] //if we wnat a class to show up in the inspector so taht we can edit it, we need to mark it as serializable

//we are going to be using this dialogue class as an object that we can pass into the dialogue manager whenever we want to start a new dialogue
//this place will hold all the information we need about a single dialogue.
//We don't need it to derive from MonoBehaviour because we don't want it to sit on a script

public class Dialogue {
    public string name; //the name of the NPC that we are talking to
    //note that if you initialize this right on top of the last } of the public class Dialogue it will give an error. 3 is minimum amount of lines the text area will use and
    //10 is the maximum
    [TextArea(3, 10)]
    public string[] sentences; //the sentences taht we will load into our Queue
    //Tyler's additions:
    //This allows for dialogue optional to quest completion:
    [TextArea(3, 10)]
    public string[] questCompletedSentences; //the sentences taht we will load into our Queue
}
