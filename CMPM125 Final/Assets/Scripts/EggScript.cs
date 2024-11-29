using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    public float minY = -10;
    public GameObject respawn;

    void Update()
    {
        // Ensure the egg respawns if it somehow falls
        if (transform.position.y < minY){
            transform.position = respawn.transform.position;
        }
    }
}
