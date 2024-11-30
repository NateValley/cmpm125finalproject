using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public int moveSpeed = 10;
    public int turnSpeed = 8;

    private Rigidbody rb;
    private bool holdingEgg = false;
    private bool eggInRange = false;
    private GameObject eggObj;
    private Rigidbody heldEggRb;

    public Transform holdPoint;
    public GameObject respawn;
    public float minY = -10;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if (eggInRange && Input.GetKeyDown(KeyCode.Space)){
            if (holdingEgg)
            {
                ReleaseEgg();
            } 
            else
            {
                GrabEgg(eggObj.GetComponent<Rigidbody>());
            }
        }

        if (transform.position.y < minY){
            transform.position = respawn.transform.position;
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
        // Move Egg along with this object 
        HandleEggHolding();
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
    }

    void OnTriggerEnter(Collider other)
	{
		// Check if the entering object is the egg
		if (other.gameObject.CompareTag("Egg"))
		{
            eggInRange = true;
            eggObj = other.gameObject;
            // Debug.Log("egg entered range");
		}
	}

    void OnTriggerExit(Collider other)
	{
        // Check if the exiting object is the egg
		if (other.gameObject.CompareTag("Egg"))
		{
            // If holding the egg, ignore this event
            if (holdingEgg && eggObj == other.gameObject)
            {
                return;
            }

            // Debug.Log("egg exited range");
            eggInRange = false;
            eggObj = null;
        }
    }

    private void GrabEgg(Rigidbody eggRb)
    {
        if (eggRb == null) { return; }

        holdingEgg = true;
        heldEggRb = eggRb;

        heldEggRb.useGravity = false;
        heldEggRb.isKinematic = false;

        heldEggRb.gameObject.layer = LayerMask.NameToLayer("HeldEgg");

        // Debug.Log("Egg Grabbed");
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

        // Debug.Log("Egg Released");
    }
}
