using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script can be added to any object but Bullet1 should be assigned as egg
public class Launch : MonoBehaviour
{
	private AudioSource audioSource;
	public float force;//How much force is used on launch
	private void OnCollisionEnter(Collision other)
	{	
		if (other.gameObject.tag == "Egg")
		{
			Rigidbody eggRB = other.gameObject.GetComponent<Rigidbody>();
			audioSource = GetComponent<AudioSource>();

			Vector3 newPosition = new Vector3(transform.position.x, eggRB.transform.position.y + 5, eggRB.transform.position.z + 5);

			if (eggRB.transform.position != newPosition && eggRB.useGravity)
			{
				eggRB.velocity = Vector3.zero;
				eggRB.transform.position = newPosition;
				audioSource.Play();
			}
			Vector3 launchForce = (Vector3.up * 2.0f + transform.forward) * force;
			eggRB.AddForce(launchForce, ForceMode.Impulse);
		}
	}

}