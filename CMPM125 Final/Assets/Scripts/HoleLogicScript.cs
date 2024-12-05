using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleEnterScript : MonoBehaviour
{
    public GameObject introPlane;
    public GameObject exitPlane;

    private AudioSource whistleDownAudio;
    private AudioSource whistleUpAudio;

    void OnCollisionEnter(Collision egg){
        Debug.Log("triggered");
        if(egg.gameObject.tag == "Egg"){
            Rigidbody egg_RigidBody = egg.gameObject.GetComponent<Rigidbody>();
            if(egg_RigidBody.useGravity)
            {
                egg.transform.position = exitPlane.transform.position;
                egg_RigidBody.AddForce(0, 0, 50, ForceMode.Impulse);
                whistleDownAudio.Play();
            }
            //whistleUpAudio.Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        whistleDownAudio = GetComponent<AudioSource>();
        //whistleUpAudio = GetComponent<AudioSource>();
    }
}
