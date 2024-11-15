<<<<<<< Updated upstream:CMPM125 Final/Assets/LaunchEgg.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script can be added to any object but Bullet1 should be assigned as egg
public class Launch : MonoBehaviour
{
    public Rigidbody bullet1;//Egg should be assigned here
	public int force;//How much force is used on launch
	private void OnTriggerStay(Collider other)
	{	
		if (other.tag == "launch")//Make tag called "launch" and add it to "Trigger" gameobject in catapult prefab
		{
			Rigidbody bullet = bullet1;
			bullet.gameObject.SetActive(true);
			bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
		}
	}

}
 
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script can be added to any object but Bullet1 should be assigned as egg
public class Launch : MonoBehaviour
{
	public float force;//How much force is used on launch
	private void OnCollisionEnter(Collision other)
	{	
		if (other.gameObject.tag == "Egg")//Make tag called "launch" and add it to "Trigger" gameobject in catapult prefab
		{
			Rigidbody eggRB = other.gameObject.GetComponent<Rigidbody>();
			eggRB.AddForce((Vector3.up * 2.0f) * force, ForceMode.Impulse);
			eggRB.AddForce(transform.forward * force, ForceMode.Impulse);
		}
	}

}
 
>>>>>>> Stashed changes:CMPM125 Final/Assets/Scripts/LaunchEgg.cs
