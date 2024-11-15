using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int moveSpeed = 10;
    public int turnSpeed = 8;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Movement Controls
        float FBInput = Input.GetAxis("Vertical");
        float LRInput = Input.GetAxis("Horizontal");

            // Forward/Backward
        Vector3 moveDirection = transform.forward * FBInput;
    

        Vector3 LRDirection = transform.right * LRInput;
    
        Vector3 totalDirection = (moveDirection + LRDirection).normalized * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + totalDirection);

        //     // Rotation
        // Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);

        // rb.MoveRotation(rb.rotation * turnRotation);
    }
}
