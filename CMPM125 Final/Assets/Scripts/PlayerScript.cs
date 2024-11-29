using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int moveSpeed = 10;
    public int turnSpeed = 8;

    private Rigidbody rb;
    private bool holdingEgg = false;
    private Rigidbody heldEggRb;

    public Transform holdPoint;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();

        // Move Egg along with this object 
        HandleEggHolding();
        // (when implementing raycast movement, do all the raycast stuff to the egg as well)
        
        // Vector3 holdPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);

        // if (holdingEgg) {
        //     heldEggRb.MovePosition(holdPosition);
        // }

        //     // Rotation
        // Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);

        // rb.MoveRotation(rb.rotation * turnRotation);

        // if (Input.GetKeyDown("space")) { releaseEgg(); }
    }

    private void HandleMovement()
    {
        // Movement Controls
        float FBInput = Input.GetAxis("Vertical");
        float LRInput = Input.GetAxis("Horizontal");

            // Forward/Backward
        Vector3 moveDirection = transform.forward * FBInput;
    

        Vector3 LRDirection = transform.right * LRInput;
    
        Vector3 totalDirection = (moveDirection + LRDirection).normalized * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + totalDirection);
    }

    private void HandleEggHolding()
    {
        if (holdingEgg && heldEggRb != null)
        {
            Vector3 moveDelta = (holdPoint.position - heldEggRb.position);

            heldEggRb.velocity = moveDelta / Time.fixedDeltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseEgg();
        }
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
            if (holdingEgg)
            {

                ReleaseEgg();

            } 
            else 
            {
                // Start Holding Egg
                // holdingEgg = true;
                // heldEggObj = other.gameObject;
                // heldEggRb = other.rigidbody;

                // other.rigidbody.useGravity = false;
                // other.rigidbody.isKinematic = true;

                // Debug.Log("holding egg");

                GrabEgg(other.rigidbody);
            }
		}
	}

    private void GrabEgg(Rigidbody eggRb)
    {
        if (eggRb == null) { return; }

        if (holdingEgg)
        {
            Debug.Log("Already Holding Egg");
            ReleaseEgg();
        }

        holdingEgg = true;
        heldEggRb = eggRb;

        heldEggRb.useGravity = false;
        heldEggRb.isKinematic = false;

        heldEggRb.gameObject.layer = LayerMask.NameToLayer("HeldEgg");

        Debug.Log("Egg Grabbed");
    }

    private void ReleaseEgg()
    {
        if (!holdingEgg || heldEggRb == null) return;
        
        if (heldEggRb != null)
        {
            heldEggRb.useGravity = true;
            heldEggRb.isKinematic = false;
            heldEggRb.gameObject.layer = LayerMask.NameToLayer("Default");

            heldEggRb.velocity = Vector3.zero;
            heldEggRb.angularVelocity = Vector3.zero;
        }
        
        holdingEgg = false;
        heldEggRb = null;

        Debug.Log("Egg Released");
    }
}
