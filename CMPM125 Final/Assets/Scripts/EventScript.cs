using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{
	public bool isTrigger; // Assumes is trigger otherwise
	public string tagToWatchFor;
  public bool disableAfter;
	public UnityEvent toRun;
	public UnityEvent toRunAfter;
 	private bool isPressed;
	
	// --------------------------------------------------------------------------------------------------
	// ---- Collision ----
	// --------------------------------------------------------------------------------------------------

	// Collisions run if isTrigger is not true
	private void OnCollisionEnter(Collision other)
	{
		// Check if the colliding object is the selected tag
		if (other.gameObject.CompareTag(tagToWatchFor) && !isPressed && !isTrigger)
		{
			// Debug.Log("Object with " + userTag + " tag has collided");
			toRun.Invoke();
			buttonAnimateDown();
		}
	}

	private void OnCollisionExit(Collision other)
	{
		// Check if the colliding object is the selected tag
		if (other.gameObject.CompareTag(tagToWatchFor) && !isPressed  && !isTrigger)
		{
			// Debug.Log("Object with " + userTag + " tag has stopped collision");
			toRunAfter.Invoke();

			// Makes it so the button is not pressed again
			if (disableAfter)
			{
				isPressed = true;
			} else {
				buttonAnimateUp();
			}
		}
	}

	// --------------------------------------------------------------------------------------------------
	// ---- Trigger ----
	// --------------------------------------------------------------------------------------------------

	// Trigger Methods run if isTrigger is true
	private void OnTriggerEnter(Collider other)
	{
		// Check if the colliding object is the selected tag
		if (other.CompareTag(tagToWatchFor) && !isPressed && isTrigger)
		{
			// Debug.Log("Object with " + userTag + " tag has entered trigger");
			toRun.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		// Check if the colliding object is the selected tag
		if (other.CompareTag(tagToWatchFor) && !isPressed  && isTrigger)
		{
			// Debug.Log("Object with " + userTag + " tag has exited trigger");
			toRunAfter.Invoke();

			// Makes it so the trigger is not triggered again
			if (disableAfter)
			{
				isPressed = true;
			} 
		}
	}

	// (JUICE TODO:) Play button animation and sfx
	private void buttonAnimateDown(){
		transform.position += new Vector3(0, -0.25f, 0);
	}

	private void buttonAnimateUp(){
		transform.position += new Vector3(0, -0.25f, 0);
	}
}

