using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f; // Forward/backward movement speed
    public float rotationSpeed = 100f;
    public Camera playerCamera; 

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");   
        float moveHorizontal = Input.GetAxis("Horizontal"); 

        if (playerCamera != null)
        {
            Vector3 cameraForward = playerCamera.transform.forward;
            cameraForward.y = 0; // Ignore vertical tilt of the camera
            cameraForward.Normalize();
            
            Vector3 movementDirection = cameraForward * moveVertical;
            transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        transform.Rotate(Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
    }
}
