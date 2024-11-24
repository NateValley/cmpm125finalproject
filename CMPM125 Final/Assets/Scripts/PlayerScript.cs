using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int moveSpeed = 10;
    public int turnSpeed = 8;

    private Rigidbody rb;
    private bool holdingEgg = false;
    private GameObject heldEggObj;
    private Rigidbody heldEggRb;
    
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
        // Move Egg along with this object 
        // (when implementing raycast movement, do all the raycast stuff to the egg as well)
        if (holdingEgg){heldEggRb.MovePosition(heldEggRb.position + totalDirection);}

        //     // Rotation
        // Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);

        // rb.MoveRotation(rb.rotation * turnRotation);

        if (Input.GetKeyDown("space")) { releaseEgg(); }
    }

    // **improvment: consider adding a child collider to the player that is called the
    // "grabbing range" or smth which has a larger collider (and is a trigger collider)
    // that runs the following code on the colling/triggering egg object**
    // If the player pressed space while touching the egg,
    // the egg will attach and move with the player
    // and turn kinematic and allow its movement to be driven by the player movement
    void OnCollisionStay(Collision other)
	{
		// Check if the colliding object is the egg
		if (other.gameObject.CompareTag("Egg") && Input.GetKeyDown("space"))
		{
            // other.transform.Find("GrabRadius");
            if (holdingEgg){
                releaseEgg();
            } else {
                // Start Holding Egg
                holdingEgg = true;
                // heldEggObj = other.gameObject;
                heldEggRb = other.rigidbody;
                other.transform.parent = transform;
                other.rigidbody.useGravity = false;
                other.rigidbody.isKinematic = true;
            }
		}
	}

    void releaseEgg(){
        if (holdingEgg){
            holdingEgg = false;
            heldEggRb.transform.parent = null;
            heldEggRb.useGravity = true;
            heldEggRb.isKinematic = false;
        }
    }
}
