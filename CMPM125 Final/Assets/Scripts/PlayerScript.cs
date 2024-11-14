using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;   
    
    void Update()
    {
        // Change GetAxisRaw to GetAxis if the movement is too snappy or something
		Vector3 moveVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		transform.position += moveVec * speed * Time.deltaTime;
    }
}
