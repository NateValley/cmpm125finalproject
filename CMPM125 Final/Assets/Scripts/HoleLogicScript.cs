using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleEnterScript : MonoBehaviour
{
    public GameObject introPlane;
    public GameObject exitPlane;
    public GameObject egg;
    public Rigidbody egg_RigidBody;

    void OnCollisionEnter(Collision egg){
        Debug.Log("triggered");
        if(egg.gameObject.CompareTag("Egg")){
            egg.transform.position = exitPlane.transform.position;
            egg_RigidBody.AddForce(0, 0, 50, ForceMode.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        egg_RigidBody = egg.GetComponent<Rigidbody>();
    }
}
