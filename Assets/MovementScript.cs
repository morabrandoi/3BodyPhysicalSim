using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float deadZoneAmt = 0.25f;
    [SerializeField]
    private float speed = .05f;

    void Update()
    {
        Vector2 touchCoords = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (touchCoords.x < -deadZoneAmt || Input.GetKey(KeyCode.A))
        {
            Debug.Log("HELLO");
            // touching left side, strafe left
            transform.Translate(-Vector3.right * /*touchCoords.x **/ Time.deltaTime * speed);
        }
        else if (touchCoords.x > deadZoneAmt || Input.GetKey(KeyCode.D))
        {
            // touching right side, strafe right
            transform.Translate(Vector3.right /** touchCoords.x*/ * Time.deltaTime * speed);
        }

        if (touchCoords.y < -deadZoneAmt || Input.GetKey(KeyCode.S))
        {
            // touching bottom side, move backwards
            transform.Translate(-Vector3.forward /** touchCoords.y */* Time.deltaTime * speed);
        }
        else if (touchCoords.y > deadZoneAmt || Input.GetKey(KeyCode.W))
        {
            // touching top side, move forward
            transform.Translate(Vector3.forward /* * touchCoords.y*/ * Time.deltaTime * speed);
        }
    }
}
