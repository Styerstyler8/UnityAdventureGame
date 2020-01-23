using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CharacterDisp : MonoBehaviour
{

    //This is the display camera of the character
    //Serialize field allows for changes to be made in unity while keeping it private
    [SerializeField] private Transform displayAnchor;

    //Rotation variables for camera
    [SerializeField] private float rotationSensitivity = 15;
    [SerializeField] private float minRotX = -360;
    [SerializeField] private float maxRotX = 360;
    [SerializeField] private float minRotY = -30;
    [SerializeField] private float maxRotY = 30;

    //Holds current values for rotations in direction
    private float rotationX;
    private float rotationY;
    private Quaternion originalRotation;

    private void Start()
    {
        //Gets the original rotation to start (get child gets the camera)
        originalRotation = displayAnchor.GetChild(0).localRotation;
    }

    void Update () {
        //Checks if mouse is over UI, if not don't rotate
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Checks if mouse is over character preview in inventory, if so then can rotate:
        //Pointer event data is used to compare
        PointerEventData pointer = new PointerEventData(EventSystem.current);

        //Gets mouse position
        pointer.position = Input.mousePosition;

        //Creates a list of raycast results based on where mouse is
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        //If raycast hit things, then loop through and check if one of those hit items is the character preview display. If so, allow rotation
        if (raycastResults.Count > 0)
        {
            foreach (var go in raycastResults)
            {
                if (go.gameObject.name.Equals("CharacterPreviewDisplay"))
                {
                    rotatePivot(displayAnchor);
                }
            }
        }

        
    }

    //Allows rotation of character preview in inventory
    private void rotatePivot(Transform pivot)
    {
        //Get axis from mouse, either moving x or y axis
        //Unity already has Mouse X and Y to get those values
        rotationX += Input.GetAxis("Mouse X") * rotationSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * rotationSensitivity;

        //Clamp ensures rotation X is between min and max
        rotationX = clampAngle(rotationX, minRotX, maxRotX);
        rotationY = clampAngle(rotationY, minRotY, maxRotY);

        //Create actual rotations now. Creates a rotation with an angle (rotationX) around the axis (2nd parameter)
        Quaternion xQuat = Quaternion.AngleAxis(rotationX, Vector2.up);
        Quaternion yQuat = Quaternion.AngleAxis(rotationY, Vector2.left);

        //Gets the camera and locally rotates it by original rotation and new rotation values
        pivot.GetChild(0).localRotation = originalRotation * xQuat * yQuat;
    }

    private float clampAngle(float angle, float min, float max)
    {
        //This makes it so that if an angle is too large it resets it to a lower number
        //Without this spinning x to 360 would make it stop after a while
        //This avoids that problem by decreasing angle
        if(angle > 360)
        {
            angle -= 360;
        }

        if(angle < -360)
        {
            angle += 360;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
