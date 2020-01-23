using UnityEngine;

public class Interactables : MonoBehaviour {

    //Range player has to be in order to interact with object
    public float interactableRadius = 3f;

    public virtual void interact()
    {
        //If every interactable has base case, add here
    }

    //Vizualises interactable radius with yellow sphere in editor. Can be nice to see
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactableRadius);
    }

    //Method to see if object is in range of player
    public void inRange(Transform playerTransform)
    {
        //Calculates distance between player and object
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if(distance <= interactableRadius)
        {
            //actually interact with object now
            interact();
        }
    }

}
