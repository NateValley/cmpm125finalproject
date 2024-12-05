using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ConveyorScript : MonoBehaviour
{
    public float speed = 5;

    void OnCollisionStay(Collision other){
        // Check if the colliding object is the selected tag
		if (other.gameObject.CompareTag("Egg") || other.gameObject.CompareTag("Player"))
		{
            Rigidbody otherRB = other.transform.GetComponent<Rigidbody>();
            // I can't believe MovePosition works from a unity thread from 2008
            otherRB.MovePosition(other.transform.position + transform.forward * Time.deltaTime * speed);
		}
    }
}
