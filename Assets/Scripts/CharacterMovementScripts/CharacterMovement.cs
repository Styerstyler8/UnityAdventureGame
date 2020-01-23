using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

//Ensures the component is here, as it depends on character controller for movement
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    

    //Needs a reference to the camera since movement is camera-relative
    [SerializeField] private Transform cam;
    Camera camera;

    //Changeable speed of rotating camera 
    public float rotSpeed = 15.0f;

    //Changeable value to adjust how fast character moves
    public float moveSpeed = 6.0f;

    //Reference to character controller
    private CharacterController charController;
    private Animator animator;
    //Variables relative to jumping
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;

    //Adjusting speed when jumping and falling
    private float vertSpeed;

    //This will be used for raycasting. Allows for accurate results if player is touching the ground or not
    private ControllerColliderHit contact;

    void Start()
    {
        //Set camera to use
        camera = Camera.main;

        //Used to get access to character controller
        charController = GetComponent<CharacterController>();

        //Initialized vertical speed
        vertSpeed = minFall;

        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void FloorSound()
    {
        RaycastHit hit = new RaycastHit();
        string floortag;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            floortag = hit.collider.gameObject.tag;
            Debug.Log(floortag);
            if (floortag == "Wood")
            {
                FindObjectOfType<DialogueAudio>().PlayWoodNoise();
            }
            else if (floortag == "Grass")
            {
                FindObjectOfType<DialogueAudio>().PlayGrassNoise();
            }
            else if (floortag == "Concrete")
            {
                FindObjectOfType<DialogueAudio>().PlayConcreteNoise();
            }
        }
    }

    void Update() {

        //This is to make sure that player is not in inventory or state where movement should not be done
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Right click interaction
        if (Input.GetMouseButtonDown(1))
        {
            //Shoots out ray from mouse position 
            Ray rightClick = camera.ScreenPointToRay(Input.mousePosition);

            //Stores info on object hit
            RaycastHit rightClickHit;

            //Cast out ray from ray, stores info in rightclickhit
            if(Physics.Raycast(rightClick, out rightClickHit, 100))
            {
                //This checks if we hit an interactable with our right click, such as an item
                Interactables interactable = rightClickHit.collider.GetComponent<Interactables>();
                if (interactable != null)
                {
                    //Goes to interactable class and sees if our player is in range of object
                    //Continues from there
                    interactable.inRange(transform);
                }
            }
        }

        bool nIsPressed = true;
        if (Input.GetKeyDown("n") && nIsPressed == false)
        {
            Debug.Log("I am here");
            animator.SetBool("nIsPressed", true);
            nIsPressed = true;
        }
        if (Input.GetKeyDown("n") && nIsPressed == true)
        {
            Debug.Log("I am here 2");
            animator.SetBool("nIsPressed", false);
            nIsPressed = false;
        }
       // animator.SetBool("isJumping", true);
        


        //Movement:



        //Starts with 0 vector and increments from there
        Vector3 movement = Vector3.zero;

        //Get input from keyboard using horizontal and vertical buttons (by default, wasd and arrows)
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        //fernando!!!!!!!!!!!
        
        //If statement so movement only done if wasd input
        if (horInput != 0 || vertInput != 0)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
            //Change the vector components to inputted, with additional multiplyer from movement speed
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;

            //This limits diagnol movement to the same as just moving on one axis
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            //This keeps the initial rotation to restore
            Quaternion tmp = cam.rotation;

            cam.eulerAngles = new Vector3(0, cam.eulerAngles.y, 0);

            //Transforms movement from local to global movement
            movement = cam.TransformDirection(movement);
            cam.rotation = tmp;

            //The lerp function here uses interpolation to allow a more smooth camera movement, while transform would cause choppy movement
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }
        else {
            animator.SetBool("isRunning", false);
            if(animator.GetBool("isJumping") == false) {
                animator.SetBool("isIdle", true);
            }
        }

        //Bool to store if ground is contacted by capsule collision (character hitbox)
        bool hitGround = false;

        //Our raycast to compare to collision
        RaycastHit hit;

        //The reason raycasting is used: if a player stands over an edge the character hitbox may detect ground but the feet will be floating above surface (think of stairs).
        //So to solve, use raycasting to project down below feet and see if ground is under feet

        //If statement checks if player is falling
        if (vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            //This is the distance to check against, extends below capsule collider 
            float check = (charController.height + charController.radius) / 1.9f;

            //hit ground is true if hit distance is less than or equal to amount check (true if ground is in a specific distance of player feet) 
            hitGround = hit.distance <= check;
        }

        //So if we are on the ground
        if (hitGround)
        {
            animator.SetBool("isJumping", false);
            if(animator.GetBool("isRunning") == false) {
                animator.SetBool("isIdle", true);
            }
            //If input is jump... set vertical speed to desired jump speed to move upwards later
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpSpeed;
            }
            else
            {
                //If no jump, then simply keep y speed as falling speed (same as before)
                vertSpeed = minFall;
            }
        }
        //Else we are not on the ground 
        else
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
            //Nice, smooth falling speed as we allow acceleration here
            vertSpeed += gravity * 5 * Time.deltaTime;

            //Ensures speed does not go to an insane amount (not over terminal speed)
            if (vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }
            //If this is true, then raycasting said not on ground, but capsule collider is saying we are on ground
            if (charController.isGrounded)
            {
                //If player is facing towards ledge he is on, allow additional movement to avoid ledge, if not then limit movement to avoid bad ledge interactions
                if (Vector3.Dot(movement, contact.normal) < 0)
                {
                    movement = contact.normal * moveSpeed;
                }
                else
                {
                    movement += contact.normal * moveSpeed;
                }
            }
        }

        //Set the movement in y to vector
        movement.y = vertSpeed;

        //This ensures movement is frame rate independent, so a faster machine does not have an advantage
        movement *= Time.deltaTime;

        //Tell character controller to get a move on
        charController.Move(movement);


        if ((horInput != 0 || vertInput != 0) && hitGround == false)
        {
            FindObjectOfType<DialogueAudio>().StopWalkingRelatedNoises();
        }
    }

    //Used for raycasting, gets a hit value from player controller and stores in our variable contact
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contact = hit;
    }
}
