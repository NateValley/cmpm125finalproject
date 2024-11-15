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
 
