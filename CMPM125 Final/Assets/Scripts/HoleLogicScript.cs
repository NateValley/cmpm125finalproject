using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleEnterScript : MonoBehaviour
{
    public GameObject introPlane;
    public GameObject exitPlane;
    public GameObject egg;
    private Rigidbody egg_RigidBody;

    private AudioSource whistleDownAudio;
    private AudioSource whistleUpAudio;

    void OnCollisionEnter(Collision egg){
        Debug.Log("triggered");
        if(egg.gameObject.CompareTag("Egg")){
            whistleDownAudio.Play();
            egg.transform.position = exitPlane.transform.position;
            egg_RigidBody.AddForce(0, 0, 50, ForceMode.Impulse);
            whistleUpAudio.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //if (egg_RigidBody)
        //{
        egg_RigidBody = egg.GetComponent<Rigidbody>();
        //}

        whistleDownAudio = GetComponent<AudioSource>();
        whistleUpAudio = GetComponent<AudioSource>();
    }
}
