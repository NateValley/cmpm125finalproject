using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
	public string tagToWatchFor;
  public bool disableAfterPress;
	public UnityEvent toRun;
	public UnityEvent toRunAfter;
 	private bool isPressed;

	private void OnCollisionEnter(Collision other)
	{
		// Check if the colliding object is the selected tag
		if (other.gameObject.CompareTag(tagToWatchFor) && !isPressed)
		{
			// Debug.Log("Object with " + userTag + " tag has collided");
			toRun.Invoke();

			// Makes it so the button is not pressed again
			if (disableAfterPress)
			{
				// (OPTIONAL JUICE) Play an animation and sound for the button being pressed down and stay down
				// Move Btn down to show it is pressed down
				transform.position += new Vector3(0, -0.25f, 0);
			} 
		}
	}

	private void OnCollisionExit(Collision other)
	{
		// Check if the colliding object is the selected tag
		if (other.gameObject.CompareTag(tagToWatchFor) && !isPressed)
		{
			// Debug.Log("Object with " + userTag + " tag has exited");
			toRunAfter.Invoke();

			if (disableAfterPress)
			{
				isPressed = true;
			} 
			// else {
				// (OPTIONAL JUICE) Play an animation and sound for the button being pressed down
			// }
		}
	}
}

