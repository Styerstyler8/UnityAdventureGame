using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //Reference to the thing the camera should move around (the player)
    public Transform person;

    //Rotation variables
    public float rotSpeed = 1.5f;

    private float rotY;
    private Vector3 offset;

    void Start()
    {
        //Stores the offset between the camera and the person
        rotY = transform.eulerAngles.y;
        offset = person.position - transform.position;
    }

    //Late update is used to make it the last thing done every frame. Makes sure person has moved first
    void LateUpdate()
    {
        //Gets the horizontal input
        float horzInput = Input.GetAxis("Horizontal");

        if (horzInput != 0)
        {
            //Rotates slowly using arrow keys
            rotY += horzInput * rotSpeed;
        }
        else
        {
            //Else rotate quicker with mouse
            rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }

        //This maintains the starting offset, and shifts according to camera rotation
        //Rotation angle converted to quaternion here
        Quaternion rotation = Quaternion.Euler(0, rotY, 0);
        transform.position = person.position - (rotation * offset);

        //This makes sure the camera is always facing the person
        transform.LookAt(person);
    }
}
