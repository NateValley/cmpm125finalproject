using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AnimateObj
{
	public GameObject animObj;
	public string animName;
	public float delay;
	[SerializeField, HideInInspector] public bool hasRun;

	// Property with a private setter to control `hasRun` externally
	public bool HasRun
	{
		get => hasRun;
		private set => hasRun = value;
	}

	// Method to mark `hasRun` as true
	public void MarkAsRun()
	{
		HasRun = true;
	}
}

[System.Serializable]
public struct ActiveObj
{
	public GameObject toChange;
	public float delay;
	[SerializeField, HideInInspector] public bool hasRun;


	// Property with a private setter to control `hasRun` externally
	public bool HasRun
	{
		get => hasRun;
		private set => hasRun = value;
	}

	// Method to mark `hasRun` as true
	public void MarkAsRun()
	{
		HasRun = true;
	}
}

public class TriggerScript : MonoBehaviour
{
	public string userTag;
	[SerializeField]
	private ActiveObj[] toDisable, toEnable;
	public AnimateObj[] toAnimate;

	private void OnTriggerEnter(Collider other)
	{
		// Check if the colliding object is the selected tag
		if (other.CompareTag(userTag))
		{
			//Debug.Log("Object with " + userTag + " tag has entered");

			// Enables each object in the array
			foreach (ActiveObj obj in toEnable)
			{
				if (!obj.hasRun)
				{
					obj.MarkAsRun();
					StartCoroutine(enableDelayed(obj, obj.delay));
				}
			}

			// Plays animations
			foreach (AnimateObj obj in toAnimate)
			{
				if (!obj.hasRun)
				{
					obj.MarkAsRun();
					StartCoroutine(playAnimDelayed(obj, obj.delay));
				}
			}

			// Disables each object in the array
			foreach (ActiveObj obj in toDisable)
			{
				if (!obj.hasRun)
				{
					obj.MarkAsRun();
					StartCoroutine(disableDelayed(obj, obj.delay));
				}
			}
		}
	}

	private IEnumerator playAnimDelayed(AnimateObj obj, float time)
	{
		// Wait for the specified interval before playing the animation
		yield return new WaitForSeconds(time);

		Animator anim = obj.animObj.GetComponent<Animator>();
		anim.Play(obj.animName);
	}

	private IEnumerator disableDelayed(ActiveObj obj, float time)
	{
		// Wait for the specified interval before playing the animation
		yield return new WaitForSeconds(time);

		obj.toChange.SetActive(false);
	}

	private IEnumerator enableDelayed(ActiveObj obj, float time)
	{
		// Wait for the specified interval before playing the animation
		yield return new WaitForSeconds(time);

		obj.toChange.SetActive(true);
	}
}
